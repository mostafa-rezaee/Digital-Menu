using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<T> GetTrackingAsync(long id);
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task<int> SaveAsync();
        Task DeleteAsync(long id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        bool IsExist(Expression<Func<T, bool>> expression);
        T GetById(long id);
    }
}
