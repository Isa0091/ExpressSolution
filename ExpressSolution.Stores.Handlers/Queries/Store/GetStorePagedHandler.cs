using ExpressSolution.Dtos.Paging;
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
    class GetStorePagedHandler : IRequestHandler<GetStorePaged, PagingOutputDto<ExpressSolution.Stores.Store>>
    {
        private readonly IStoreRepo _storeRepo;
        public GetStorePagedHandler(
            IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }
        public async Task<PagingOutputDto<ExpressSolution.Stores.Store>> Handle(GetStorePaged request, CancellationToken cancellationToken)
        {
            PagingOutputDto<ExpressSolution.Stores.Store> storesPaged =
                await _storeRepo.GetListStorePaged(request.NameContains, request.Active,request.PageNumber,request.ResultPerPage);
            return storesPaged;
        }
    }
}
