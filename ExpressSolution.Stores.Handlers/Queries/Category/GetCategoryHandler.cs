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
    class GetCategoryHandler : IRequestHandler<GetCategory, List<ExpressSolution.Stores.Category>>
    {
        private readonly ICategoryRepo _categoryRepo;
        public GetCategoryHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<List<Stores.Category>> Handle(GetCategory request, CancellationToken cancellationToken)
        {
            List<Stores.Category> categories=await _categoryRepo.GetCategoriesFilter(request.NameContains, request.Active);
            return categories;
        }
    }
}
