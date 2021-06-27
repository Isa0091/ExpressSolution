using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class DeleteContactFromStore : CommandBase 
    {
        /// <summary>
        /// Identificador del cliente
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Identificador del contacto
        /// </summary>
        public string ContactId { get; set; }
    }
}
