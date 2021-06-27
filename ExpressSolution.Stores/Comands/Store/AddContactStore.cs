using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class AddContactStore : CommandBase
    {
        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Identificadro del contacto
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Datos del contacto
        /// </summary>
        public ContactDataVo ContactData { get; set; }
    }
}
