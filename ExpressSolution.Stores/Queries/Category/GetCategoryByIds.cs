using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Category
{
    public class GetCategoryByIds : QueryBase<List<ExpressSolution.Stores.Category>>
    {
        /// <summary>
        /// listado de codigos de categorias
        /// </summary>
        public List<string> CategoryIds { get; set; }
    }
}
