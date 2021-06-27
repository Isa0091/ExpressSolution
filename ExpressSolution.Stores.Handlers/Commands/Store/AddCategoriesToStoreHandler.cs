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
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La tienda consultada no existe");

            store.AddCategory(request.Categories);
            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
