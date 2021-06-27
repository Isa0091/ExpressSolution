using ExpressSolution.Dtos.Paging;
using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Category
{
    public class GetCategoryPaged :  QueryBase<PagingOutputDto<ExpressSolution.Stores.Category>>
    {
        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        public string NameContains { get; set; }

        /// <summary>
        /// Indica si esta activa o no la categoria
        /// </summary>
        public bool? IsActive { get; set; }
        /// <summary>
        /// Numero de pagina
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Cantidad de resultados por pagina
        /// </summary>
        public int ResultPerPage { get; set; }
    }
}
