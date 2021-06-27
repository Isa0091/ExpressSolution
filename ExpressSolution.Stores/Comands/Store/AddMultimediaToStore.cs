using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Comands.Store
{
    public class AddMultimediaToStore : CommandBase
    {
        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        public string StoreId { get; set; }
        /// <summary>
        /// Identificadro de la multimedia
        /// </summary>
        public string MultimediaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<byte> Multimedia { get; set; }

        /// <summary>
        /// url de la multimedia dependiendo de <see cref="MultimediaType"/>
        /// </summary>
        public string UrlMultimedia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultimediaType MultimediaType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MultimediaRelevance MultimediaRelevance { get; set; }
    }
}
