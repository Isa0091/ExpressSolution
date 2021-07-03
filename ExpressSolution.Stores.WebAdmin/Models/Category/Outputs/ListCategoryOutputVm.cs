using ExpressSolution.Stores.WebAdmin.Models.Category.Inputs;
using ExpressSolution.Stores.WebAdmin.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Outputs
{
    public class ListCategoryOutputVm
    {
        /// <summary>
        /// Filtros
        /// </summary>
        public FilterCategoryInputVm Filter { get; set; }
        /// <summary>
        /// Listado de categorias
        /// </summary>
        public List<CategoryOutputVm> Categories { get; set; }

        /// <summary>
        /// paginacion
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
