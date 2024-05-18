using AutoMapper;
using Maxi.Application.DTO.Brand;
using Maxi.Application.DTO.Product;
using Maxi.Domain;
using Maxi.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.Services.Interface
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
       
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,  IMapper mapper)
        {
            _productRepository= productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto createproductDto)
        {
            var product = _mapper.Map<Product>(createproductDto);
            var data = await _productRepository.CreateAsync(product);
            var entity = _mapper.Map<ProductDto>(data);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await  _productRepository.GetByIdAsyn(x => x.Id == id);
            await  _productRepository.DeleteAsync(data);
        }

        public async  Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var data = await  _productRepository.Getallproductasync();

            return _mapper.Map<List<ProductDto>>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetAllByFilterAsync(int? categoryId, int? brandId)
        {
            var query = await _productRepository.Getallproductasync();
            if(categoryId>0)
            {
                query=query.Where(x=> x.CategoryId == categoryId);
            }
            if(brandId>0)
            {
                query=query.Where(x=> x.BrandId == brandId);
            }

            var result = _mapper.Map<List<ProductDto>>(query);
            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var data = await  _productRepository.GetByidAsync(id);
            return _mapper.Map<ProductDto>(data);
        }

       

        public async Task UpdateAsync(UpdateProductDto updateproductDto)
        {

            var data = _mapper.Map<Product>(updateproductDto);
            await  _productRepository.UpdateAsync(data);
        }
    }
}
