using ExpressSolution.Exceptions;
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
    class GetCategoryByIdHandler : IRequestHandler<GetCategoryById,ExpressSolution.Stores.Category>
    {
        private readonly ICategoryRepo _categoryRepo;

        GetCategoryByIdHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Stores.Category> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            Stores.Category category = await _categoryRepo.GetById(request.CategoryId);

            if (category == null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La categoria consultada no existe");

            return category;
        }
    }
}