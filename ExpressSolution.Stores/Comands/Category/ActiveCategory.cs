using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Category
{
    public class ActiveCategory :  CommandBase
    {
        /// <summary>
        /// Identificadro de la categoria
        /// </summary>
        public string CategoryId { get; set; }
    }
}
