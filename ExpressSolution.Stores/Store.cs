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
            StoreCategories = new List<StoreCategory>();
            DynamicData = new List<DynamicDataVo>();
            Contacts = new List<StoreContact>();
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
        /// Categorias a la que pertenece esta empresa
        /// </summary>
        public List<MultimediaStore> Multimedia { get; set; }

        /// <summary>
        /// Listado de categorias
        /// </summary>
        public List<StoreCategory> StoreCategories { get; set; }

        public void AddDynamicData(DynamicDataVo dynamicData)
        {
            DynamicDataVo dynamic = DynamicData.SingleOrDefault(x => x.DataName.Trim().ToLower() == dynamicData.DataName.Trim().ToLower());

            if (dynamic != null)
                DynamicData.Remove(dynamic);

            DynamicData.Add(dynamicData with { });
        }

        public void AddDynamicData(List<DynamicDataVo> listDynamicData)
        {
            foreach (DynamicDataVo dynamicData in listDynamicData)
            {
                AddDynamicData(dynamicData);
            }
        }

        /// <summary>
        /// Valida si existe el DynamicData y remueve el vo
        /// </summary>
        /// <param name="name"></param>
        public void RemoveDynamicData(string name)
        {
            DynamicDataVo dynamicData = DynamicData.FirstOrDefault(x => x.DataName.Trim().ToLower() == name.Trim().ToLower());

            if (dynamicData == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.AccountDynamicData, nameof(name), this.GetType());

            DynamicData.Remove(dynamicData);
        }

        /// <summary>
        /// Obtengo un dato dinamico por su name
        /// </summary>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public DynamicDataVo GetDynamicData(string dataName)
        {
            DynamicDataVo dynamic = DynamicData.SingleOrDefault(x => x.DataName.Trim().ToLower() == dataName.Trim().ToLower());
            return dynamic;
        }
    }
}
