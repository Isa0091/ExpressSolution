using ExpressSolution.Dtos.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data
{
    /// <summary>
    /// maneja la data de la categoria
    /// </summary>
    public interface ICategoryRepo :  IBaseRepo<string, Category>
    {
        /// <summary>
        /// Obtengo las categorias filtradas
        /// </summary>
        /// <param name="nameContains"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategoriesFilter(string nameContains, bool? isActive);

        /// <summary>
        /// Listado de categorias paginado
        /// </summary>
        /// <param name="nameContains"></param>
        /// <param name="isActive"></param>
        /// <param name="pageNumber"></param>
        /// <param name="resultPerPage"></param>
        /// <returns></returns>
        Task<PagingOutputDto<Category>> GetListCategoryPaged(string nameContains, bool? isActive, int pageNumber, int resultPerPage);
        
        /// <summary>
        /// listado de categorias filtrado por ids
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategoriesByIds(List<string> categoryIds = null);
    }
}
