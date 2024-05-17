using Maxi.Domain;
using Maxi.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Infrastructure.Common
{
    public class SeedData
    {
        public static async Task SeedDataAsync(ApplicationDbContext _db)
        {
            if(!_db.brands.Any())
            {
                await _db.AddRangeAsync(
                    new Brand { name = "Samsung", EstablishYear = System.DateTime.UtcNow },
                    new Brand { name = "lenovo", EstablishYear = System.DateTime.UtcNow },
                    new Brand { name = "hp", EstablishYear = System.DateTime.UtcNow },
                    new Brand { name = "dell", EstablishYear = System.DateTime.UtcNow },
                    new Brand { name = "asus", EstablishYear = System.DateTime.UtcNow });
            }
            await _db.SaveChangesAsync();
        }
    }
}
