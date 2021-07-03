using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Outputs
{
    public class StoreContactOutputVm
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre del contacto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Numero fijo
        /// </summary>
        public string LandLineNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
