using ExpressSolution.Dtos.Paging;
using ExpressSolution.Stores.Comands.Category;
using ExpressSolution.Stores.Queries.Category;
using ExpressSolution.Stores.WebAdmin.Extensions;
using ExpressSolution.Stores.WebAdmin.Models.Category;
using ExpressSolution.Stores.WebAdmin.Models.Category.Inputs;
using ExpressSolution.Stores.WebAdmin.Models.Category.Outputs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private int _resultPerPage;

        public CategoryController(
            IMediator mediator)
        {
            _mediator = mediator;
            _resultPerPage = 10;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FilterCategoryInputVm filter, int page = 1)
        {
            if (filter == null)
                filter = new FilterCategoryInputVm();

            PagingOutputDto<ExpressSolution.Stores.Category> result=await _mediator.Send(new GetCategoryPaged()
            {
                 IsActive= filter.State != null ? ((int)filter.State.Value).GetEnumToBoolValue() : null,
                 NameContains=filter.NameContains,
                 PageNumber= page,
                 ResultPerPage= _resultPerPage
            });

            List<CategoryOutputVm> categories =
                result.PaginatedList.Select(z => new CategoryOutputVm()
                {
                     Active= z.Active,
                     DateCreated= z.DateCreated.ToString("dd/MM/yyyy"),
                     Description= z.Description.Description,
                     Id= z.Id,
                     MultimediaType= z.Logo.MultimediaType,
                     Name= z.Name,
                     UrlMultimedia= z.Logo.UrlMultimedia
                }).ToList();

            ListCategoryOutputVm listCategoryOutputVm = new ListCategoryOutputVm()
            {
                Categories = categories,
                Filter = filter,
                PagingInfo = new Models.Paging.PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = _resultPerPage,
                    TotalItems = result.TotalItems
                }
            };

            return View(listCategoryOutputVm);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            ViewBag.success = TempData["success"];
            DetailCategoryOutputVm detailCategory = await GetCategoryOutput(id);
            return View(detailCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Detail(CategoryInputVm categoryInputVm)
        {
            string categoryId = categoryInputVm.Id;

            if (ModelState.IsValid == false)
            {
                DetailCategoryOutputVm detailCategory = await GetCategoryOutput(categoryInputVm.Id);
                detailCategory.CategoryInputVm = categoryInputVm;
                return View(detailCategory);
            }

            if (string.IsNullOrEmpty(categoryInputVm.Id))
            {
                categoryId = Guid.NewGuid().ToString();
                List<byte> multimediaBytes = await GetBytesImagenAsync(categoryInputVm.Multimedia);

                await _mediator.Send(new CreateCategory()
                {
                    Id = categoryId,
                    CategoryData = new Dtos.Category.CategoryData()
                    {
                        Description = new DescriptionVo(categoryInputVm.Description, categoryInputVm.ExtendedDescription),
                        Name = categoryInputVm.Name,
                        MimeType = categoryInputVm.Multimedia.ContentType,
                        Multimedia = multimediaBytes,
                        MultimediaName = categoryInputVm.Multimedia.FileName,
                        MultimediaType = MultimediaType.Image
                    }
                });

            }

            if (string.IsNullOrEmpty(categoryInputVm.Id) == false)
            {
                EditCategory editCategory =
                    new EditCategory()
                    {
                        Id = categoryId,
                        CategoryData = new Dtos.Category.CategoryData()
                        {
                            Description = new DescriptionVo(categoryInputVm.Description, categoryInputVm.ExtendedDescription),
                            Name = categoryInputVm.Name
                        }
                    };

                if (categoryInputVm.Multimedia != null)
                {
                    List<byte> multimediaBytes = await GetBytesImagenAsync(categoryInputVm.Multimedia);
                    editCategory.CategoryData.MimeType = categoryInputVm.Multimedia.ContentType;
                    editCategory.CategoryData.Multimedia = multimediaBytes;
                    editCategory.CategoryData.MultimediaName = categoryInputVm.Multimedia.FileName;
                    editCategory.CategoryData.MultimediaType = MultimediaType.Image;
                }
                await _mediator.Send(editCategory);
            }

            TempData["success"] = "Datos generales guardados correctamente";
            return RedirectToAction("Detail", new { id = categoryId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveDynamicData(DynamicDataCategoryInputVm  dynamicDataCategory)
        {
            AddDynamicDataToCategory command = new AddDynamicDataToCategory
            {
                CategoryId = dynamicDataCategory.CategoryId,
                DynamicDataVo = new DynamicDataVo(dynamicDataCategory.DataName,dynamicDataCategory.DataValue)
            };

            await _mediator.Send(command);

            TempData["success"] = "Dato adicional guardado exitosamente";

            return RedirectToAction("Detail", new { id = dynamicDataCategory.CategoryId });
        }


        [HttpGet]
        public async Task<IActionResult> DeleteData(string categoryId, string name)
        {
            RemoveDynamicDataFromCategory command = new RemoveDynamicDataFromCategory
            {
                CategoryId = categoryId,
                DataName = name
            };

            await _mediator.Send(command);
            TempData["success"] = "Dato eliminado exitosamente";

            return RedirectToAction("Detail", new { id = categoryId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStateCategory(string categoryId, bool state)
        {
            if (state == false)
                await _mediator.Send(new InactivateCategory()
                {
                    CategoryId = categoryId
                });

            if (state)
                await _mediator.Send(new ActiveCategory()
                {
                    CategoryId = categoryId
                });

            return Json(new { exitoso = true });
        }
        #region Metodos privados
        /// <summary>
        /// Obtengo los bytes de un IFormFile
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        private async Task<List<byte>> GetBytesImagenAsync(IFormFile imagen)
        {
            List<byte> imagenBytes = new List<byte>();
            using (var memoryStream = new MemoryStream())
            {
                await imagen.CopyToAsync(memoryStream);
                imagenBytes = memoryStream.ToArray().ToList();

            }

            return imagenBytes;
        }
        /// <summary>
        /// Obtengo el output de la categoria
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private async Task<DetailCategoryOutputVm> GetCategoryOutput(string categoryId)
        {
            DetailCategoryOutputVm detailCategory = new DetailCategoryOutputVm();

            if (string.IsNullOrEmpty(categoryId) == false)
            {
                Category category = await _mediator.Send(new GetCategoryById()
                {
                    CategoryId = categoryId

                });

                detailCategory.Active = category.Active;
                detailCategory.DateCreated = category.DateCreated.ToString("dd/MM/yyyy");
                detailCategory.DynamicData = category.DynamicData;
                detailCategory.MimeType = category.Logo.MimeType;
                detailCategory.MultimediaType = category.Logo.MultimediaType;
                detailCategory.UrlMultimedia = category.Logo.UrlMultimedia;

                detailCategory.CategoryInputVm.Id = category.Id;
                detailCategory.CategoryInputVm.Name = category.Name;
                detailCategory.CategoryInputVm.Description = category.Description.Description;
                detailCategory.CategoryInputVm.ExtendedDescription = category.Description.ExtendedDescription;

                detailCategory.DynamicDataCategory.CategoryId = categoryId;
            }

            return detailCategory;
        }
        #endregion

    }
}
