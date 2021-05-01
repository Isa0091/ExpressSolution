using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores
{
    public class MultimediaStore : Entity
    {
        public MultimediaStore()
        {
            DateCreated = DateTimeOffset.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Fceha en que se creo
        /// </summary>
        public DateTimeOffset DateCreated { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public MultimediaRelevance MultimediaRelevance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MultimediaVo DataMultimedia { get; set; }

        /// <summary>
        /// Foranea
        /// </summary>
        public string StoreId { get; set; }
    }
}
