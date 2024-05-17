using Maxi.Domain.Contracts;
using Maxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Maxi.Infrastructure.DbContexts;

namespace Maxi.Infrastructure.Repositories
{
    public class BrandRrepository : GenericRepository<Brand>, IBrandRepository
    {

        public BrandRrepository(ApplicationDbContext db):base(db)
        {
            
        }

        public async Task UpdateAsync(Brand brand)
        {
            _db.Update(brand);
            await _db.SaveChangesAsync();
        }
    }
}
