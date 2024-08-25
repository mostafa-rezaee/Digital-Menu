using Common.Domain;
using Common.Domain.Repositories;
using DigiMenu.Infrastracture.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture._Utilities
{
    public class BaseRepository<TEntity> : Common.Domain.Repositories.BaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DigiMenuContext _context;
        public BaseRepository(DigiMenuContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        void Common.Domain.Repositories.BaseRepository<TEntity>.Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public TEntity? GetById(long id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity?> GetTrackingAsync(long id)
        {
            return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)); }

        public async Task<bool> HasRecordAsync()
        {
            return await _context.Set<TEntity>().AnyAsync();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Any(expression);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
