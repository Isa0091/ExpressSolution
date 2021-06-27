using ExpressSolution.Dtos.Paging;
using ExpressSolution.Stores.Data;
using ExpressSolution.Stores.Queries.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Queries.Category
{
    class GetCategoryPagedHandler : IRequestHandler<GetCategoryPaged, PagingOutputDto<ExpressSolution.Stores.Category>>
    {
        private readonly ICategoryRepo _categoryRepo;
        public  GetCategoryPagedHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<PagingOutputDto<ExpressSolution.Stores.Category>> Handle(GetCategoryPaged request, CancellationToken cancellationToken)
        {
            PagingOutputDto<ExpressSolution.Stores.Category> categoriesPaged =
                await _categoryRepo.GetListCategoryPaged(request.NameContains, request.IsActive,request.PageNumber,request.ResultPerPage);

            return categoriesPaged;
        }
    }
}
