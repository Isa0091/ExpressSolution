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

        public async Task<List<Category>> GetCategoriesFilter(string CategoryName, bool? isActive)
        {
            List<Category> result=await _db.Categories.Where(x => (CategoryName == null || x.Name.Contains(CategoryName)) &&
                                        (isActive == null || x.Active == isActive)).ToListAsync();
            return result;
        }
    }
}
