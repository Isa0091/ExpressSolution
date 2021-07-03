using ExpressSolution.Dtos.Paging;
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

            }

            return detailStore;
        }

        #endregion
    }
}
