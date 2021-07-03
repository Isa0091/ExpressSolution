using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs
{
    public class MultimediaStoreInputVm
    {
        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        [Required(ErrorMessage = "El identificadro de la tienda es requerido")]
        public string StoreId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IFormFile Multimedia { get; set; }

        /// <summary>
        /// url de la multimedia dependiendo de <see cref="MultimediaType"/>
        /// </summary>
        public string UrlMultimedia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "El tipo de multimedia es requerido")]
        public MultimediaType? MultimediaType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "La relevancia del a multimedia es requerida")]
        public MultimediaRelevance? MultimediaRelevance { get; set; }
    }
}
