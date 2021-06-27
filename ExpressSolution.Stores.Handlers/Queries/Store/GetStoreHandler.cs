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
    class GetStoreHandler : IRequestHandler<GetStore, List<ExpressSolution.Stores.Store>>
    {
        private readonly IStoreRepo _storeRepo;
        public GetStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<List<Stores.Store>> Handle(GetStore request, CancellationToken cancellationToken)
        {
            List<ExpressSolution.Stores.Store> stores = await _storeRepo.GetStoreFilter(request.NameContains, request.Active);
            return stores;
        }
    }
}
