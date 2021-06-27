using ExpressSolution.Exceptions;
using ExpressSolution.Stores.Comands.Category;
using ExpressSolution.Stores.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Commands.Category
{
    class RemoveDynamicDataFromCategoryHandler : IRequestHandler<RemoveDynamicDataFromCategory>
    {
        private readonly ICategoryRepo _categoryRepo;

        public RemoveDynamicDataFromCategoryHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Unit> Handle(RemoveDynamicDataFromCategory request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Category category = await _categoryRepo.GetById(request.CategoryId);

            if (category == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Category, nameof(request), this.GetType());

            category.RemoveDynamicData(request.DataName);

            await _categoryRepo.SaveChangesAsync();
            await _categoryRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
