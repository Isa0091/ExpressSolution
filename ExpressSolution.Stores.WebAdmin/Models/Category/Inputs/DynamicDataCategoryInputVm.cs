using ExpressSolution.Stores.WebAdmin.Models.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Inputs
{
    public class DynamicDataCategoryInputVm : DynamicDataInputVm
    {
        /// <summary>
        /// Identificadro de la categoria
        /// </summary>
        [Required(ErrorMessage = "El identificadro de la categoria es requerido")]
        public string CategoryId { get; set; }
    }
}
