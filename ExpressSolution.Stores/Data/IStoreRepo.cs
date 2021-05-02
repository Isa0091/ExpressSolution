using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data
{
    /// <summary>
    /// Manejala data de las tiendas
    /// </summary>
    public interface IStoreRepo : IBaseRepo<string, Store>
    {
    }
}
