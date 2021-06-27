using ExpressSolution.Stores.Dtos.Category;
using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Category
{
    public class CreateCategory : CommandBase
    {
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Data de la categoria
        /// </summary>
        public CategoryData CategoryData { get; set; }
    }
}
