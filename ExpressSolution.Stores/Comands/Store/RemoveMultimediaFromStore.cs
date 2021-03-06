using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class RemoveMultimediaFromStore : CommandBase
    {
        /// <summary>
        /// Identificador de la multimedia
        /// </summary>
        public string MultimediaId { get; set; }

        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        public string StoreId { get; set; }
    }
}
