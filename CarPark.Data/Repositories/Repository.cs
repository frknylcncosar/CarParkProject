using CarPark.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Data.Repositories {
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();//!
        }
        public async Task AddAsync(TEntity entity) {
            await _dbSet.AddAsync(entity);//await işlem bitene kadar bu satırda kalmayı sağlar
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity) {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity) {
            //savechanges metodu nerede kullanılırsa bu entityi orada değiştirecek
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
