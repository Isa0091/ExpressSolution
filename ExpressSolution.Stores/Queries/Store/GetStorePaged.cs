using ExpressSolution.Dtos.Paging;
using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Store
{
    public class GetStorePaged :  QueryBase<PagingOutputDto<ExpressSolution.Stores.Store>>
    {
    }
}
