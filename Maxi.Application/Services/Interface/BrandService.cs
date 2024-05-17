using AutoMapper;
using Maxi.Application.DTO.Brand;
using Maxi.Application.DTO.Category;
using Maxi.Domain;
using Maxi.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.Services.Interface
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository= brandRepository;
            _mapper=mapper;
        }
        public async Task<BrandDto> CreateAsync(CreateBrandDto createbrandDto)
        {
            var brand = _mapper.Map<Brand>(createbrandDto);
            var data = await _brandRepository.CreateAsync(brand);
            var entity = _mapper.Map<BrandDto>(data);
            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _brandRepository.GetByIdAsyn(x => x.Id == id);
            await _brandRepository.DeleteAsync(data);
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var data = await _brandRepository.GetAllAsync();

            return _mapper.Map<List<BrandDto>>(data);
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var data = await _brandRepository.GetByIdAsyn(x => x.Id == id);
            return _mapper.Map<BrandDto>(data);
        }

        public async Task UpdateAsync(UpdateBrandDto updateBrandDto)
        {
            var data = _mapper.Map<Brand>(updateBrandDto);
            await _brandRepository.UpdateAsync(data);
        }
    }
}
