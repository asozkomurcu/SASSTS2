using Microsoft.EntityFrameworkCore;
using SASSTS2.Domain.Common;
using SASSTS2.Domain.Repositories;
using SASSTS2.Persistence.Context;
using System.Linq;
using System.Linq.Expressions;

namespace SASSTS2.Persistence.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public Repository(SASSTSContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync(params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query);
        }

        public async Task<IQueryable<T>> GetAllNameAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<IQueryable<T>> GetBetweenDateAsync(DateTime date1, DateTime date2, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            //return await Task.FromResult(query.ToArray<DateTime>(date1-date2));
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<IQueryable<T>> GetByNameFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<IQueryable<T>> GetByDateFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }


        public async Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
        }

        
    }
}
