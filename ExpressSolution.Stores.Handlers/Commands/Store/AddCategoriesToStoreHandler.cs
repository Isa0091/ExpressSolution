using ExpressSolution.Exceptions;
using ExpressSolution.Stores.Comands.Store;
using ExpressSolution.Stores.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Commands.Store
{
    class AddCategoriesToStoreHandler : IRequestHandler<AddCategoriesToStore>
    {
        private readonly IStoreRepo _storeRepo;
        public AddCategoriesToStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(AddCategoriesToStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            if (request.Categories == null)
                store.StoreCategories = new List<StoreCategory>();

            if (request.Categories != null)
            {
                List<string> actuallyCategories = store.StoreCategories.Select(z => z.CategoryId).ToList();

                //categorias a remover porque ya no los enviaron
                List<string> categoriesToRemove = actuallyCategories.Where(z => !request.Categories.Contains(z)).ToList();
                store.RemoveCategory(categoriesToRemove);

                //categorias a agregar porque no esta en las categorias actuales
                List<string> categoriessToAdd = request.Categories.Where(z => !actuallyCategories.Contains(z)).ToList();
                store.AddCategory(categoriessToAdd);
            }

            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
