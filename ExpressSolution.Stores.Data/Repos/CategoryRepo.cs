using ExpressSolution.Dtos.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Category>> GetCategoriesFilter(string nameContains, bool? isActive)
        {
            List<Category> result=await _db.Categories.Where(x => (nameContains == null || x.Name.Contains(nameContains)) &&
                                        (isActive == null || x.Active == isActive)).ToListAsync();
            return result;
        }

        public async Task<PagingOutputDto<Category>> GetListCategoryPaged(string nameContains, bool? isActive, int pageNumber, int resultPerPage)
        {
            Expression<Func<Category, bool>> where = x => (nameContains == null || x.Name.Contains(nameContains)) &&
                                                           (isActive == null || x.Active == isActive);

            int itemSkip = resultPerPage * (pageNumber - 1);

            List<Category> lista = await _db.Categories.Where(where).OrderBy(x => x.Id).Skip(itemSkip).Take(resultPerPage).ToListAsync();

            int cantidad = await _db.Categories.CountAsync(where);

            return new PagingOutputDto<Category>(lista, cantidad);
        }


        public async Task<List<Category>> GetCategoriesByIds(List<string> categoryIds=null)
        {
            List<Category> result = await _db.Categories.Where(x => (categoryIds==null || categoryIds.Contains(x.Id))).ToListAsync();
            return result;
        }
    }
}
