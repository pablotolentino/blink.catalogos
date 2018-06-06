using Catalogs.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalogs.Data.Repositories
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        internal DbSet<TEntity> _dbSet;
        internal CatalogsContext _context;
        public GenericRepository(CatalogsContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {               
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual Task<TEntity> GetByID(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);            
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        //public virtual void Delete(TEntity entityToDelete)
        //{
            //if (_context.Entry(entityToDelete).State == EntityState.Detached)
            //{
            //    _dbSet.Attach(entityToDelete);
            //}
            //_dbSet.Remove(entityToDelete);
        //}

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

}
