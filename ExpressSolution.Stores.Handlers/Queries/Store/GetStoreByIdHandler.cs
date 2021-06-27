using ExpressSolution.Exceptions;
using ExpressSolution.Stores.Data;
using ExpressSolution.Stores.Queries.Store;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Queries.Store
{
    class GetStoreByIdHandler : IRequestHandler<GetStoreById, ExpressSolution.Stores.Store>
    {
        private readonly IStoreRepo _storeRepo;
        public GetStoreByIdHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Stores.Store> Handle(GetStoreById request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if(store==null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La tienda consultada no existe");

            return store;
        }
    }
}