using ExpressSolution.Stores.WebAdmin.Models.Store.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Outputs
{
    public class DetailStoreOutputVm
    {
        public DetailStoreOutputVm()
        {
            StoreInput = new StoreInputVm();
            DynamicDataStore = new DynamicDataStoreInputVm();
            Categories = new List<string>();
            MultimediaStoreOutput = new List<MultimediaStoreOutputVm>();
            StoreContactOutputs = new List<StoreContactOutputVm>();
            MultimediaStoreInput = new MultimediaStoreInputVm();
        }
        /// <summary>
        /// Input store
        /// </summary>
        public StoreInputVm StoreInput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Datos adicionales que se epueden agregar 
        /// </summary>
        public List<DynamicDataVo> DynamicData { get; set; }

        /// <summary>
        /// Listado de categorias de la tienda
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Listado de multimedias asociadas 
        /// </summary>
        public List<MultimediaStoreOutputVm> MultimediaStoreOutput { get; set; }

        /// <summary>
        /// Listado de contactos de la tienda
        /// </summary>
        public List<StoreContactOutputVm> StoreContactOutputs { get; set; }
        /// <summary>
        /// Input para guardar campos dinamicos
        /// </summary>
        public DynamicDataStoreInputVm DynamicDataStore { get; set; }

        /// <summary>
        /// Datos para ingresar una multimedia
        /// </summary>
        public MultimediaStoreInputVm MultimediaStoreInput { get; set; }
    }
}
