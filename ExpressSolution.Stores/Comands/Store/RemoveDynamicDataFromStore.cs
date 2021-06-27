using Isa0091.Domain.Core.Commands;

namespace ExpressSolution.Stores.Comands.Store
{
    public class RemoveDynamicDataFromStore : CommandBase
    {
        /// <summary>
        /// Identificador de la tienda
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Nombre del dato que se desea eliminar
        /// </summary>
        public string DataName { get; set; }
    }
}