using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Category
{

    public class AddDynamicDataToCategory : CommandBase
    {
        /// <summary>
        /// identificador de la categoria
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Datos dinamicos a agregar
        /// </summary>
        public DynamicDataVo DynamicDataVo { get; set; }
    }
}
