using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Inputs
{
    public class FilterCategoryInputVm
    {
        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        public string NameContains { get; set; }

        /// <summary>
        /// Indica si esta activa o no la categoria
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
