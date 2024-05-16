using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain.Contracts
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
       public Task UpdateAsync(Category category);
    }
}
