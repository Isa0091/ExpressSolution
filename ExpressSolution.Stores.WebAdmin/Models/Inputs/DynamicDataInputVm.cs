using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Inputs
{
    public class DynamicDataInputVm
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "La longitud del nombre debe ser {1}")]
        public string DataName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "El valor es requerido")]
        public string DataValue { get; set; }

    }
}
