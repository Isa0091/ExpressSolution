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

        public async Task<List<Store>> GetStoreFilter(string nameContains, bool? isActive)
        {
            List<Store> result = await _db.Stores.Where(x => (nameContains == null || x.Name.Contains(nameContains)) &&
                                          (isActive == null || x.Active == isActive)).ToListAsync();
            return result;
        }

        public async Task<PagingOutputDto<Store>> GetListStorePaged(string nameContains, bool? isActive, int pageNumber, int resultPerPage)
        {
            Expression<Func<Store, bool>> where = x => (nameContains == null || x.Name.Contains(nameContains)) &&
                                                           (isActive == null || x.Active == isActive);

            int itemSkip = resultPerPage * (pageNumber - 1);

            List<Store> lista = await _db.Stores.Where(where).OrderBy(x => x.Id).Skip(itemSkip).Take(resultPerPage).ToListAsync();

            int cantidad = await _db.Stores.CountAsync(where);

            return new PagingOutputDto<Store>(lista, cantidad);
        }
    }
}
    
