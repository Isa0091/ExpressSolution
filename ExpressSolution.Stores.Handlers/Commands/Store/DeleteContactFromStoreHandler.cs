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
    class DeleteContactFromStoreHandler : IRequestHandler<DeleteContactFromStore>
    {
        private readonly IStoreRepo _storeRepo;
        public DeleteContactFromStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(DeleteContactFromStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            store.DeleteContact(request.ContactId);
            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}