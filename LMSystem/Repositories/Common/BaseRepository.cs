using LMSystem.DAO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMSystem.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LMSystemDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(LMSystemDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void Create(T entity)
        {
          _dbContext.Add<T>(entity);
        }

        public void Delete(T entity)
        {
           _dbContext.Update<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsEnumerable();

        }

        public IEnumerable<T> Getby(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().Where(expression).AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbContext.Update<T>(entity);
        }

        
    }
}
