using Maxi.Domain;
using Maxi.Domain.Contracts;
using Maxi.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            
        }

        public async Task<IEnumerable<Product>> Getallproductasync()
        {
            return await _db.products.Include(x=>x.Category).Include(x=>x.Brand).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByidAsync(int id)
        {
            return await _db.products.Include(x => x.Category).Include(x => x.Brand).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
