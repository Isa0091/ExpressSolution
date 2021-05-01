using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores
{
    /// <summary>
    /// 
    /// </summary>
    public class Category : RootEntity
    {

        public Category()
        {
            DateCreated = DateTimeOffset.Now;
        }
        /// <summary>
        /// Identificador unicode la categoria
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset DateCreated { get; private set; }
        /// <summary>
        /// 
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UrlLogo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DescriptionVo Description { get; set; }

        /// <summary>
        /// Datos adicionales que se epueden agregar 
        /// </summary>
        public List<DynamicDataVo> DynamicData { get; set; }
    }
}
