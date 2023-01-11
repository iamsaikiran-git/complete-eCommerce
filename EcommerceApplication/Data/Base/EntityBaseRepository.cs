using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApplication.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;
        public EntityBaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            var res = await appDbContext.Set<T>().AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await appDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await appDbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var actor = await appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
