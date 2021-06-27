using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Store
{
    public class GetStoreById : QueryBase<ExpressSolution.Stores.Store>
    {
        /// <summary>
        /// Identificadro de la tienda
        /// </summary>
        public string StoreId { get; set; }
    }
}
