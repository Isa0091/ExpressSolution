using ExpressSolution.Stores.WebAdmin.Models.Category.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Category.Outputs
{
    public class DetailCategoryOutputVm
    {
        public DetailCategoryOutputVm()
        {
            CategoryInputVm = new CategoryInputVm();
            DynamicDataCategory = new DynamicDataCategoryInputVm();
        }
        /// <summary>
        /// Data a editar de la category
        /// </summary>
        public  CategoryInputVm CategoryInputVm { get; set; }

        /// <summary>
        /// Input para guardar campos dinamicos
        /// </summary>
        public DynamicDataCategoryInputVm DynamicDataCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DateCreated { get;  set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }

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

        /// <summary>
        /// Datos adicionales que se epueden agregar 
        /// </summary>
        public List<DynamicDataVo> DynamicData { get; set; }
    }
}
