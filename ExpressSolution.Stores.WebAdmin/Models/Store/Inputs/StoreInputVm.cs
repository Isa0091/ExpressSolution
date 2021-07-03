using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs
{
    public class StoreInputVm
    {
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripcion corta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Opcional: descripcion larga
        /// </summary>
        public string ExtendedDescription { get; set; }
    }
}
