using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Category
{
    public class GetCategoryById : QueryBase<ExpressSolution.Stores.Category>
    {
        /// <summary>
        /// Identificadro de la categoria
        /// </summary>
        public string CategoryId { get; set; }
    }
}
