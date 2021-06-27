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
    class CreateCategoryHandler : IRequestHandler<CreateCategory>
    { 
        private readonly IManagerFileEasyAzureProvider _managerFileEasyAzureProvider;
        private readonly ICategoryRepo _categoryRepo;

        public CreateCategoryHandler(
            IManagerFileEasyAzureProvider managerFileEasyAzureProvider,
            ICategoryRepo categoryRepo)
        {
            _managerFileEasyAzureProvider = managerFileEasyAzureProvider;
            _categoryRepo = categoryRepo;
        }

        public async Task<Unit> Handle(CreateCategory request, CancellationToken cancellationToken)
        {

           Uri urlImage= await _managerFileEasyAzureProvider.PostFileStorageAsync(request.CategoryData.Multimedia.ToArray(), request.CategoryData.MultimediaName, request.CategoryData.MimeType);

            ExpressSolution.Stores.Category Category = new ExpressSolution.Stores.Category()
            {
                 Active= true,
                 Description= request.CategoryData.Description with { },
                 Id= request.Id,
                 Logo= new MultimediaVo(request.CategoryData.MultimediaName, request.CategoryData.MimeType, urlImage.ToString(), MultimediaType.Image),
                 Name= request.CategoryData.Name
            };

            await _categoryRepo.AddAsync(Category);
            await _categoryRepo.SaveChangesAsync();

            return new Unit();
        }
    }
}
