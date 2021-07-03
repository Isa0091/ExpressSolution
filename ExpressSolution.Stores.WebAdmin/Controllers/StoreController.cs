using ExpressSolution.Dtos.Paging;
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
    }
}
