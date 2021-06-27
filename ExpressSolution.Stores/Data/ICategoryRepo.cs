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
        /// <param name="CategoryName"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategoriesFilter(string CategoryName, bool? isActive);
    }
}
