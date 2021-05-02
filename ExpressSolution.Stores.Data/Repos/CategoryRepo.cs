using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data.Repos
{
    public class CategoryRepo : BaseRepo<string, Category>, ICategoryRepo
    {
        private readonly StoreContext _db;
        public CategoryRepo(StoreContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<Category> GetById(string id)
        {
            return await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
