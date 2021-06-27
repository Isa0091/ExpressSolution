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
    class AddMultimediaToStoreHandler : IRequestHandler<AddMultimediaToStore>
    {
        private readonly IStoreRepo _storeRepo;
        private readonly IManagerFileEasyAzureProvider _managerFileEasyAzureProvider;
        public AddMultimediaToStoreHandler(
            IStoreRepo storeRepo,
            IManagerFileEasyAzureProvider managerFileEasyAzureProvider)
        {
            _storeRepo = storeRepo;
            _managerFileEasyAzureProvider = managerFileEasyAzureProvider;
        }
        public async Task<Unit> Handle(AddMultimediaToStore request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Store store = await _storeRepo.GetById(request.StoreId);

            if (store == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Store, nameof(request), this.GetType());

            if (request.MultimediaType == MultimediaType.ExternalLink || request.MultimediaType == MultimediaType.YouTubeLink &&
               string.IsNullOrEmpty(request.UrlMultimedia))
               throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"Si se definen el tipo de multimedia externo es necesario enviar  la url");

            if (request.MultimediaType != MultimediaType.ExternalLink || request.MultimediaType != MultimediaType.YouTubeLink &&
                string.IsNullOrEmpty(request.UrlMultimedia)==false)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"Si se  envia una url externa es necesario definir un tipo externo");

            if(request.MultimediaType != MultimediaType.ExternalLink || request.MultimediaType != MultimediaType.YouTubeLink &&
                request.Multimedia.Any()==false)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"Debe enviar el archivo en base al tipo elegido");

            string urlMultimedia = request.UrlMultimedia;

            if(request.MultimediaType == MultimediaType.Video || request.MultimediaType==MultimediaType.Image || request.MultimediaType== MultimediaType.Audio)
            {
                Uri urlMultimediaStorage =
                    await _managerFileEasyAzureProvider.PostFileStorageAsync(request.Multimedia.ToArray(), request.Name, request.MimeType);
                urlMultimedia = urlMultimediaStorage.ToString();
            }

            store.AddMultimedia(request.MultimediaId, request.MultimediaRelevance, new MultimediaVo(request.Name,request.MimeType,urlMultimedia,request.MultimediaType));

            await _storeRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
