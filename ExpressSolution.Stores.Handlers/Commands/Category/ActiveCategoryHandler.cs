﻿using ExpressSolution.Exceptions;
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
    class ActiveCategoryHandler : IRequestHandler<ActiveCategory>
    {
        private readonly ICategoryRepo _categoryRepo;

        ActiveCategoryHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Unit> Handle(ActiveCategory request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Category category = await _categoryRepo.GetById(request.CategoryId);

            if (category == null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La categoria consultada no existe");

            category.Active = true;

            await _categoryRepo.SaveChangesAsync();
            await _categoryRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
