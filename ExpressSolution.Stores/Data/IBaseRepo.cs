using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.Data
{
    /// <summary>
    /// Repo base parafacilitar la crteacion de los otros repsitorios
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepo<TKey, TEntity> where TEntity : RootEntity
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entidad);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();

        /// <summary>
        /// Saca todas la sentidades de la base
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAll();

        /// <summary>
        /// Saca una entodad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(TKey id);
    }
}
