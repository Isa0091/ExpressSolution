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
    class InactivateCategoryHandler : IRequestHandler<InactivateCategory>
    {
        private readonly ICategoryRepo _categoryRepo;

        InactivateCategoryHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Unit> Handle(InactivateCategory request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Category category = await _categoryRepo.GetById(request.CategoryId);

            if (category == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Category, nameof(request), this.GetType());

            category.Active = false;

            await _categoryRepo.SaveChangesAsync();
            await _categoryRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
