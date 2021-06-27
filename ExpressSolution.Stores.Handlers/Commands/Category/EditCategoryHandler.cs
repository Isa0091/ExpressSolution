using ExpressSolution.Exceptions;
using ExpressSolution.Stores.Comands.Category;
using ExpressSolution.Stores.Data;
using ManagerFileEasyAzure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Handlers.Commands.Category
{
    class EditCategoryHandler : IRequestHandler<EditCategory>
    {
        private readonly IManagerFileEasyAzureProvider _managerFileEasyAzureProvider;
        private readonly ICategoryRepo _categoryRepo;

        EditCategoryHandler(
            IManagerFileEasyAzureProvider managerFileEasyAzureProvider,
            ICategoryRepo categoryRepo)
        {
            _managerFileEasyAzureProvider = managerFileEasyAzureProvider;
            _categoryRepo = categoryRepo;
        }
        public async Task<Unit> Handle(EditCategory request, CancellationToken cancellationToken)
        {
            ExpressSolution.Stores.Category category = await _categoryRepo.GetById(request.Id);

            if(category==null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(request), this.GetType(), $"La categoria consultada no existe");

            if(request.CategoryData.Multimedia.Any())
            {
                await  _managerFileEasyAzureProvider.DeleteFile(new Uri(category.Logo.UrlMultimedia));
                Uri urlImage = await _managerFileEasyAzureProvider.PostFileStorageAsync(request.CategoryData.Multimedia.ToArray(), request.CategoryData.MultimediaName, request.CategoryData.MimeType);
                category.Logo = new MultimediaVo(request.CategoryData.MultimediaName, request.CategoryData.MimeType, urlImage.ToString(), MultimediaType.Image);
            }

            category.Description = request.CategoryData.Description with { };
            category.Name = request.CategoryData.Name;
            return new Unit();
        }
    }
}
