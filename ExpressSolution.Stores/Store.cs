using ExpressSolution.Exceptions;
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
            Multimedia = new List<MultimediaStore>();
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
                throw NotFoundException.CreateException(NotFoundExceptionType.DynamicData, nameof(name), this.GetType());

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

        /// <summary>
        /// Agrega una categoria a la tienda
        /// </summary>
        /// <param name="categoryId"></param>
         public void AddCategory(string categoryId)
        {
            StoreCategory storeCategory = StoreCategories.SingleOrDefault(x => x.CategoryId== categoryId);

            if (storeCategory != null)
                throw ClientException.CreateException(ClientExceptionType.InvalidOperation, nameof(categoryId), this.GetType(), $"La categoria esta repetida, ya ha sido asignada");

            StoreCategories.Add(new StoreCategory() { 
                 CategoryId= categoryId
            });
        }

        /// <summary>
        /// agrega un listado de categorias a la tienda
        /// </summary>
        /// <param name="listCategories"></param>
        public void AddCategory(List<string> listCategories)
        {
            foreach (string categoryId in listCategories)
            {
                AddCategory(categoryId);
            }
        }

        /// <summary>
        /// Agrega los datos de un contacto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactData"></param>
        /// <returns></returns>
        public StoreContact AddStoreContact(string id, ContactDataVo contactData)
        {
            StoreContact contact = new StoreContact
            {
                Id = id,
                ContactData = contactData with { }
            };

            Contacts.Add(contact);

            return contact;
        }

        /// <summary>
        /// Elimina los datos de un contacto
        /// </summary>
        /// <param name="contactId"></param>
        public void DeleteContact(string contactId)
        {
            StoreContact contact = Contacts.FirstOrDefault(x => x.Id == contactId);

            if (contact == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Contact, nameof(contactId), this.GetType());

            Contacts.Remove(contact);
        }

        /// <summary>
        /// Agrega una categoria a la tienda
        /// </summary>
        /// <param name="categoryId"></param>
        public MultimediaStore AddMultimedia(string idMultimedia, MultimediaRelevance multimediaRelevance, MultimediaVo multimediaVo)
        {
            MultimediaStore multimediaStore = new MultimediaStore()
            {
                 Id= idMultimedia,
                 MultimediaRelevance= multimediaRelevance,
                 DataMultimedia= multimediaVo with { },
            };

            Multimedia.Add(multimediaStore);

            return multimediaStore;
        }

        /// <summary>
        /// Elimina una categoria
        /// </summary>
        /// <param name="CategoryId"></param>
        public void RemoveCategory(string CategoryId)
        {
           StoreCategory storeCategory= StoreCategories.SingleOrDefault(z => z.CategoryId == CategoryId);

            if(storeCategory==null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Category, nameof(CategoryId), this.GetType());

            StoreCategories.Remove(storeCategory);
        }

        /// <summary>
        /// Elimina una categoria
        /// </summary>
        /// <param name="CategoryId"></param>
        public void RemoveCategory(List<string> categoryId)
        {
            foreach(string categoriId in categoryId)
            {
                RemoveCategory(categoryId);
            }
        }

        /// <summary>
        /// Obtengo la data de la multimedia store por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MultimediaStore GetMultimediaStore(string id)
        {
            MultimediaStore multimedia = Multimedia.SingleOrDefault(z => z.Id == id);

            if (multimedia == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Multimedia, nameof(id), this.GetType());

            return multimedia;
        }

        /// <summary>
        /// Remuevo la multimedia storage de la tienda
        /// </summary>
        /// <param name="id"></param>
        public void RemoveMultimedia(string id)
        {
            MultimediaStore multimediaStore = GetMultimediaStore(id);
            Multimedia.Remove(multimediaStore);
        }
    }
}
