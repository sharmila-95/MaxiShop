using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain.Contracts
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<IEnumerable<Product>> Getallproductasync();

        public Task<Product> GetByidAsync(int id);
        
        public Task UpdateAsync(Product product);
    }
}
