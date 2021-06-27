using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Inputs
{
    public class CategoryInputVm
    {
        /// <summary>
        /// Identificador unicode la categoria
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// imagen
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        /// <summary>
        /// imagen
        /// </summary>
        [Required(ErrorMessage = "La multimedia a guardar es requerida")]
        public IFormFile Multimedia { get; set; }

        /// <summary>
        /// descripcion
        /// </summary>
        [Required(ErrorMessage = "La descripcion a guardar es requerida")]
        public string  Description { get; set; }

        /// <summary>
        /// Descripcion extendida
        /// </summary>
        public string ExtendedDescription { get; set; }
    }
}
