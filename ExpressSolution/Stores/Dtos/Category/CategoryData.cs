using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Dtos.Category
{
    public class CategoryData
    {
        public CategoryData()
        {
            Multimedia = new List<byte>();
        }
        /// <summary>
        /// Nombre de la categoria
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MultimediaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<byte> Multimedia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultimediaType MultimediaType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DescriptionVo Description { get; set; }
    }
}
