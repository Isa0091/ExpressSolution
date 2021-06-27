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
    class EditStoreHandler : IRequestHandler<EditStore>
    {
        private readonly IStoreRepo _storeRepo;
        public EditStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(EditStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.Id);

            if(store==null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            store.Name = request.StoreData.Name;
            store.Description = request.StoreData.Description with { };

            await _storeRepo.SaveChangesAsync();
            return new Unit();
        }
    }
}
