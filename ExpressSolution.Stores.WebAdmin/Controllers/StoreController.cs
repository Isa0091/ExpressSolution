using ExpressSolution.Dtos.Paging;
using ExpressSolution.Stores.Comands.Store;
using ExpressSolution.Stores.Queries.Category;
using ExpressSolution.Stores.Queries.Store;
using ExpressSolution.Stores.WebAdmin.Extensions;
using ExpressSolution.Stores.WebAdmin.Models.Store.Inputs;
using ExpressSolution.Stores.WebAdmin.Models.Store.Outputs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Controllers
{
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        private int _resultPerPage;

        public StoreController(
            IMediator mediator)
        {
            _mediator = mediator;
            _resultPerPage = 10;
        }
        [HttpGet]
        public async Task<IActionResult> Index(FilterStoreInputVm filter, int page = 1)
        {
            if (filter == null)
                filter = new FilterStoreInputVm();

            PagingOutputDto<ExpressSolution.Stores.Store> result = await _mediator.Send(new GetStorePaged()
            {
                Active = filter.State != null ? ((int)filter.State.Value).GetEnumToBoolValue() : null,
                NameContains = filter.NameContains,
                PageNumber = page,
                ResultPerPage = _resultPerPage
            });


            List<StoreOutputVm> stores = result.PaginatedList.Select(z => new StoreOutputVm()
            {
                  Active= z.Active,
                  DateCreated= z.DateCreated.ToString("dd/MM/yyyy"),
                  Description= z.Description.Description,
                  Id= z.Id,
                  Name= z.Name

            }).ToList();

            ListStoreOutputVm listStoreOutputVm = new ListStoreOutputVm()
            {
                Filter = filter,
                Stores = stores,
                PagingInfo = new Models.Paging.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = _resultPerPage,
                    TotalItems = result.TotalItems
                }
            };

            return View(listStoreOutputVm);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            ViewBag.success = TempData["success"];
            DetailStoreOutputVm detailStore = await GetDetailStoreOutputVm(id);

            return View(detailStore);
        }

        [HttpGet]
        public async Task<IActionResult> StoreCategories(string storeId)
        {
            List<CategoryStoreInputVm> categoryStores = new List<CategoryStoreInputVm>();
            Store store = await _mediator.Send(new GetStoreById()
            {
                StoreId = storeId
            });

            List<Category> categories = await _mediator.Send(new GetCategory());
            List<string> idCategoriesStore = store.StoreCategories.Select(z => z.CategoryId).ToList();

            foreach(Category category in categories)
            {
                categoryStores.Add(new CategoryStoreInputVm()
                {
                     Id= category.Id,
                     Name= category.Name,
                     Selected= idCategoriesStore.Contains(category.Id)
                });
            }

            string html = await this.RenderViewAsync("_StoreCategories", categoryStores);
            return Json(new { existoso = true, html = html });

        }

        [HttpPost]
        public async Task<IActionResult> Detail(StoreInputVm storeInput)
        {
            string storeId = storeInput.Id;

            if (ModelState.IsValid == false)
            {
                DetailStoreOutputVm detailStore = await GetDetailStoreOutputVm(storeInput.Id);
                detailStore.StoreInput = storeInput;
                return View(detailStore);
            }

            if(string.IsNullOrEmpty(storeInput.Id))
            {
                storeId = Guid.NewGuid().ToString();
                await _mediator.Send(new CreateStore()
                { 
                  Id= storeId,
                  StoreData= new Dtos.Store.StoreData()
                  {
                       Description= new DescriptionVo(storeInput.Description, storeInput.ExtendedDescription),
                       Name= storeInput.Name
                  }
                });
            }

            if (string.IsNullOrEmpty(storeInput.Id)==false)
            {
                await _mediator.Send(new EditStore()
                {
                    Id = storeId,
                    StoreData = new Dtos.Store.StoreData()
                    {
                        Description = new DescriptionVo(storeInput.Description, storeInput.ExtendedDescription),
                        Name = storeInput.Name
                    }
                });
            }

            TempData["success"] = "Datos generales guardados correctamente";
            return RedirectToAction("Detail", new { id = storeId });
        }

            [HttpPost]
        public async Task<IActionResult> SaveDynamicData(DynamicDataStoreInputVm dynamicDataStore)
        {
            AddDynamicDataToStore command = new AddDynamicDataToStore
            {
                StoreId = dynamicDataStore.StoreId,
                DynamicData = new DynamicDataVo(dynamicDataStore.DataName, dynamicDataStore.DataValue)
            };

            await _mediator.Send(command);

            TempData["success"] = "Dato adicional guardado exitosamente";

            return RedirectToAction("Detail", new { id = dynamicDataStore.StoreId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteData(string storeId, string name)
        {
            RemoveDynamicDataFromStore command = new RemoveDynamicDataFromStore
            {
                StoreId= storeId,
                DataName = name
            };

            await _mediator.Send(command);
            TempData["success"] = "Dato eliminado exitosamente";

            return RedirectToAction("Detail", new { id = storeId });
        }


        #region Metodos privados 
        /// <summary>
        /// Obengop el output el detalle de la tienda
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        private async Task<DetailStoreOutputVm> GetDetailStoreOutputVm(string storeId)
        {
            DetailStoreOutputVm detailStore = new DetailStoreOutputVm();

            if (string.IsNullOrEmpty(storeId) == false)
            {
                Store store = await _mediator.Send(new GetStoreById()
                {
                    StoreId = storeId
                });

                detailStore.Active = store.Active;
                detailStore.DateCreated = store.DateCreated.ToString("dd/MM/yyyy");
                detailStore.DynamicData = store.DynamicData;

                detailStore.StoreInput.Id = store.Id;
                detailStore.StoreInput.Name = store.Name;
                detailStore.StoreInput.Description = store.Description.Description;
                detailStore.StoreInput.ExtendedDescription = store.Description.ExtendedDescription;

                detailStore.DynamicDataStore.StoreId = storeId;

                List<Category> categories = await _mediator.Send(new GetCategoryByIds()
                {
                    CategoryIds= store.StoreCategories.Select(z=>z.CategoryId).ToList() 
                });

                detailStore.Categories = categories.Select(z => z.Name).ToList();

                detailStore.MultimediaStoreOutput = store.Multimedia.Select(z => new MultimediaStoreOutputVm()
                {
                     Id= z.Id,
                     MimeType= z.DataMultimedia.MimeType,
                     MultimediaRelevance= z.MultimediaRelevance,
                     MultimediaType= z.DataMultimedia.MultimediaType,
                     UrlMultimedia= z.DataMultimedia.UrlMultimedia

                }).ToList();

                detailStore.StoreContactOutputs = store.Contacts.Select(z => new StoreContactOutputVm()
                {
                     Email= z.ContactData.Email,
                     Id= z.Id,
                     LandLineNumber= z.ContactData.LandLineNumber,
                     MobileNumber= z.ContactData.MobileNumber,
                     Name= z.ContactData.Name

                }).ToList();

            }

            return detailStore;
        }

        #endregion
    }
}
