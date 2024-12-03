using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        protected AppDbContext Context = context;

        private readonly DbSet<T> _dbset = context.Set<T>();

        
        public async ValueTask Add(T entitiy)
        {
            await _dbset.AddAsync(entitiy);
        }

        public  void Delete(T entity)
        {
             _dbset.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable().AsNoTracking();
        }

        public ValueTask<T?> GetByIdAsync(int id) => _dbset.FindAsync(id);

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).AsNoTracking();
        }
    }
}
