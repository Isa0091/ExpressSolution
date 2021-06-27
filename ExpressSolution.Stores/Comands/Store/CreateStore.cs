using ExpressSolution.Stores.Dtos.Store;
using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class CreateStore : CommandBase
    {
        /// <summary>
        /// Identificador de la store
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Data de la store
        /// </summary>
        public StoreData StoreData { get; set; }
    }
}
