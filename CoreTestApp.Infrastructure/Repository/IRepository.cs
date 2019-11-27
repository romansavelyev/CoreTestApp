using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreTestApp.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        ValueTask<T> GetByIdAsync(object id);
        
        Task CreateAsync(T entity);

        Task Delete(Guid id);

        Task Update(T entity);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}