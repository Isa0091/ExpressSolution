using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class ActiveStore : CommandBase
    {
        /// <summary>
        /// Identificadro de la tienda
        /// </summary>
        public string StoreId { get; set; }
    }
}
