using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores
{
    public class StoreContact : Entity
    {

        public StoreContact()
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
        public ContactDataVo ContactData { get; set; }

        /// <summary>
        /// para la llave foranea
        /// </summary>
        public string StoreId { get; private set; }

        public override void IsValid()
        {
            base.IsValid();
        }
    }
}
