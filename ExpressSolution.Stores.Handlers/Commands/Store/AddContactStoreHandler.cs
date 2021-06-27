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
    class AddContactStoreHandler : IRequestHandler<AddContactStore>
    {
        private readonly IStoreRepo _storeRepo;
        public AddContactStoreHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<Unit> Handle(AddContactStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            store.AddStoreContact(request.ContactId,request.ContactData);
            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
