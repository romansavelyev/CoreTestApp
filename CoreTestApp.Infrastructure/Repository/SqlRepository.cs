using System;
using System.Threading;
using System.Threading.Tasks;
using CoreTestApp.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CoreTestApp.Infrastructure.Repository
{
    public class SqlRepository<T> : ISqlRepository<T> 
        where T : class
    {
        private readonly CoreTestAppContext _context;

        public SqlRepository(CoreTestAppContext context)
        {
            this._context = context;
        }

        public async ValueTask<T> GetByIdAsync(object id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(T).ToString());
            }

            await this._context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var existing = await this._context.Set<T>().FindAsync(id);
            this._context.Set<T>().Remove(existing);
        }

        public async Task Update(T entity)
        {
            this._context.Set<T>().Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}