using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Outputs
{
    public class StoreOutputVm
    {
        /// <summary>
        /// Identificador unicode la tienda
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// fecha de creacion de latienda
        /// </summary>
        public string DateCreated { get;  set; }

        /// <summary>
        /// Descripcion corta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
