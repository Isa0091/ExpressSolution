using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Outputs
{
    /// <summary>
    /// Multimedia
    /// </summary>
    public class MultimediaStoreOutputVm
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MultimediaRelevance MultimediaRelevance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrlMultimedia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultimediaType MultimediaType { get; set; }
    }
}
