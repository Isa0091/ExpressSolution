using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Queries.Category
{
    public class GetCategory : QueryBase<List<ExpressSolution.Stores.Category>>
    {
        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Si esta activa o incactiva la categoria
        /// </summary>
        public bool? Active { get; set; }
    }
}
