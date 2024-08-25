using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repositories
{
    public interface BaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(long id);
        Task<T?> GetTrackingAsync(long id);
        Task AddAsync(T entity);
        void Add(T entity);
        void Update(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task<int> SaveAsync();
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        bool IsExist(Expression<Func<T, bool>> expression);
        T? GetById(long id);
        Task<bool> HasRecordAsync();
    }
}
