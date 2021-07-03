using ExpressSolution.Stores.WebAdmin.Models.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs
{
    public class DynamicDataStoreInputVm : DynamicDataInputVm
    {
        /// <summary>
        /// Identificadro de la categoria
        /// </summary>
        [Required(ErrorMessage = "El identificadro de la tienda es requerido")]
        public string StoreId { get; set; }
    }
}
