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
    class GetCategoryByIdsHandler : IRequestHandler<GetCategoryByIds, List<ExpressSolution.Stores.Category>>
    {
        private readonly ICategoryRepo _categoryRepo;
        public GetCategoryByIdsHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<List<Stores.Category>> Handle(GetCategoryByIds request, CancellationToken cancellationToken)
        {
            List<Stores.Category> categories = await _categoryRepo.GetCategoriesByIds(request.CategoryIds);
            return categories;
        }
    }
}
