using ExpressSolution.Dtos.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data
{
    /// <summary>
    /// Manejala data de las tiendas
    /// </summary>
    public interface IStoreRepo : IBaseRepo<string, Store>
    {
        /// <summary>
        /// Listado de tiendas filtrado
        /// </summary>
        /// <param name="nameContains"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<List<Store>> GetStoreFilter(string nameContains, bool? isActive);

        /// <summary>
        /// Listado filtrado de tiendas y paginado
        /// </summary>
        /// <param name="nameContains"></param>
        /// <param name="isActive"></param>
        /// <param name="pageNumber"></param>
        /// <param name="resultPerPage"></param>
        /// <returns></returns>
        Task<PagingOutputDto<Store>> GetListStorePaged(string nameContains, bool? isActive, int pageNumber, int resultPerPage);
    }
}
