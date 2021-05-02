using Isa0091.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data.Repos
{
    public abstract class BaseRepo<TKey, TEntity> : IBaseRepo<TKey, TEntity> where TEntity : RootEntity
    {
        protected readonly StoreContext Db;

        protected BaseRepo(StoreContext db)
        {
            Db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entidad)
        {
            await Db.Set<TEntity>().AddAsync(entidad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task<TEntity> GetById(TKey id);
    }
}
