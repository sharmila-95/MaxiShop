using Maxi.Application.DTO.Brand;
using Maxi.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.Services.Interface
{
    public interface IProductService
    {
       
        Task<ProductDto> GetByIdAsync(int id);

        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<IEnumerable<ProductDto>> GetAllByFilterAsync(int? categoryId, int? brandId);

        Task<ProductDto> CreateAsync(CreateProductDto createproductDto);
        Task UpdateAsync(UpdateProductDto updateproductDto);
        Task DeleteAsync(int id);
    }
}
