using Maxi.Domain.Common;
using Maxi.Domain.Contracts;
using Maxi.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {

        protected readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var data=await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return data.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();  
        }

        public async Task<T> GetByIdAsyn(Expression<Func<T, bool>> condition)
        {
           return await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        }
    }
}
