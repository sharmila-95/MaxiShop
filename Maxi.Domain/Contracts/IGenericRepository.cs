using Maxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain.Contracts
{
    public interface IGenericRepository<T> where T : BaseModel
    {

        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsyn(Expression<Func<T, bool>> condition);

    }
}
