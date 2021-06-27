using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Dtos.Paging
{
    /// <summary>
    /// Informacion para manejar listas paginadas
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagingOutputDto<TEntity> where TEntity : new()
    {
        public PagingOutputDto(List<TEntity> paginatedList, int totalItems)
        {
            PaginatedList = paginatedList;
            TotalItems = totalItems;
        }

        /// <summary>
        /// Listado paginado de la entidad
        /// </summary>
        public List<TEntity> PaginatedList { get; set; }

        /// <summary>
        /// Total de items
        /// </summary>
        public int TotalItems { get; set; }
    }
}
