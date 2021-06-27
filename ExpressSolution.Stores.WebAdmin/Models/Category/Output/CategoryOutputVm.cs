using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Output
{
    public class CategoryOutputVm
    {
        /// <summary>
        /// Identificador unicode la categoria
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DateCreated { get;  set; }
        /// <summary>
        /// 
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UrlMultimedia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultimediaType MultimediaType { get; set; }
    }
}
