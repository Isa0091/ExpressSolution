using ExpressSolution.Exceptions;
using ExpressSolution.Stores.Comands.Store;
using ExpressSolution.Stores.Data;
using ManagerFileEasyAzure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Commands.Store
{
    class RemoveMultimediaFromStoreHandler : IRequestHandler<RemoveMultimediaFromStore>
    {
        private readonly IStoreRepo _storeRepo;
        private readonly IManagerFileEasyAzureProvider _managerFileEasyAzureProvider;
        public RemoveMultimediaFromStoreHandler(
            IStoreRepo storeRepo,
            IManagerFileEasyAzureProvider managerFileEasyAzureProvider)
        {
            _storeRepo = storeRepo;
            _managerFileEasyAzureProvider = managerFileEasyAzureProvider;
        }
        public async Task<Unit> Handle(RemoveMultimediaFromStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La tienda consultada no existe");

            MultimediaStore multimediaStore = store.GetMultimediaStore(request.MultimediaId);

            if(multimediaStore.DataMultimedia.MultimediaType != MultimediaType.ExternalLink || 
               multimediaStore.DataMultimedia.MultimediaType != MultimediaType.YouTubeLink)
            {
                await _managerFileEasyAzureProvider.DeleteFile(new Uri(multimediaStore.DataMultimedia.UrlMultimedia));
            }

            store.RemoveMultimedia(request.MultimediaId);
            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}