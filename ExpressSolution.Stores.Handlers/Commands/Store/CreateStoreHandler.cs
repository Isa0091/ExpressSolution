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
    class CreateStoreHandler : IRequestHandler<CreateStore>
    {
        private readonly IStoreRepo _storeRepo;
        public CreateStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(CreateStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = new Stores.Store()
            {
                Active = true,
                Description = request.StoreData.Description with { },
                Name = request.StoreData.Name,
                Id = request.Id

            };

            await _storeRepo.AddAsync(store);
            await _storeRepo.SaveChangesAsync();
            return new Unit();
        }
    }
}
