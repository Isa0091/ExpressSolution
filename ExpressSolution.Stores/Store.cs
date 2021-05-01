using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores
{
    public class Store : RootEntity
    {
        public Store ()
        {
            DateCreated = DateTimeOffset.Now;
        }
        /// <summary>
        /// Identificador unicode la tienda
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// fecha de creacion de latienda
        /// </summary>
        public DateTimeOffset DateCreated { get; private set; }

        /// <summary>
        /// Url del logo
        /// </summary>
        public string UrlLogo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DescriptionVo Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Datos adicionales que se epueden agregar 
        /// </summary>
        public List<DynamicDataVo> DynamicData { get; set; }

        /// <summary>
        /// Los contactos de la tienda
        /// </summary>
        public List<StoreContact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<MultimediaStore> Multimedia { get; set; }
        /// <summary>
        /// Foranea
        /// </summary>
        public string IdCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Category Category { get; set; }
    }
}
