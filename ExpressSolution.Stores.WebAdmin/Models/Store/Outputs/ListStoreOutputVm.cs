using ExpressSolution.Stores.WebAdmin.Models.Paging;
using ExpressSolution.Stores.WebAdmin.Models.Store.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Outputs
{
    public class ListStoreOutputVm
    {
        /// <summary>
        /// Filtros
        /// </summary>
        public FilterStoreInputVm Filter { get; set; }
        /// <summary>
        /// Listado de categorias
        /// </summary>
        public List<StoreOutputVm> Stores { get; set; }

        /// <summary>
        /// paginacion
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
