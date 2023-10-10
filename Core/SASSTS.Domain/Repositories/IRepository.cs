using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(params string[] includeColumns);
        Task<IQueryable<T>> GetAllNameAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<IQueryable<T>> GetBetweenDateAsync(DateTime date1,DateTime date2,params string[] includeColumns);
        Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<IQueryable<T>> GetByNameFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<IQueryable<T>> GetByDateFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<T> GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
