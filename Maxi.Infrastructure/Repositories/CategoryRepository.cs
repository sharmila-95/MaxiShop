using Maxi.Domain;
using Maxi.Domain.Contracts;
using Maxi.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository

    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task UpdateAsync(Category category)
        {
         _db.Update(category);
            await _db.SaveChangesAsync();
        }
    }
}
