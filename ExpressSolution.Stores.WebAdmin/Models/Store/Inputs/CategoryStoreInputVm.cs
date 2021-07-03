using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs
{
    public class CategoryStoreInputVm
    {
        /// <summary>
        /// Identificador unicode la categoria
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// category
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Indica si esta seleccionada
        /// </summary>
        public bool Selected { get; set; }
    }
}
