using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data.Repos
{
    public class StoreRepo : BaseRepo<string, Store>, IStoreRepo
    {
        private readonly StoreContext _db;
        public StoreRepo(StoreContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<Store> GetById(string id)
        {
            return await _db.Stores.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
