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
    class RemoveDynamicDataFromStoreHandler : IRequestHandler<RemoveDynamicDataFromStore>
    {
        private readonly IStoreRepo _storeRepo;
        public RemoveDynamicDataFromStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(RemoveDynamicDataFromStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            store.RemoveDynamicData(request.DataName);
            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}