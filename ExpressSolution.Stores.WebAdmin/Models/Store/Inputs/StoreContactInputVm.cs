using ExpressSolution.Stores.WebAdmin.Models.Store.Inputs.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs
{
    public class StoreContactInputVm
    {
        /// <summary>
        /// 
        /// </summary>
        public string StoreId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(300, ErrorMessage = "La longitud del nombre debe ser {1}")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ValidateContacAttribute]
        [StringLength(50, ErrorMessage = "La longitud la linea fija debe ser {1}")]
        public string LandLineNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [EmailAddress(ErrorMessage = "El formato del email es incorrecto")]
        [StringLength(200, ErrorMessage = "La longitud del email debe ser {1}")]
        public string Email { get; set; }
    }
}
