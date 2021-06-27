using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores
{
    /// <summary>
    /// Listado de categorias
    /// </summary>
    public class StoreCategory
    {
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        ///^para crear la foranea
        /// </summary>
        private Category Category { get; set; }
    }
}
