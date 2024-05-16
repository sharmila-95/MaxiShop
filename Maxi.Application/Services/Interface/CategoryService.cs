using AutoMapper;
using Maxi.Application.DTO.Category;
using Maxi.Domain;
using Maxi.Domain.Contracts;

namespace Maxi.Application.Services.Interface
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository= categoryRepository;
            _mapper= mapper;
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            var data=await _categoryRepository.CreateAsync(category);
            var entity=_mapper.Map<CategoryDto>(data);
            return entity;
        }


        public async Task DeleteAsync(int id)
        {
            var data = await _categoryRepository.GetByIdAsyn(x=>x.Id==id);
            await _categoryRepository.DeleteAsync(data);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var data=await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryDto>>(data);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var data=await _categoryRepository.GetByIdAsyn(x=>x.Id==id);
            return _mapper.Map<CategoryDto>(data);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var data=_mapper.Map<Category>(updateCategoryDto);
            await _categoryRepository.UpdateAsync(data);
        }
    }
}
