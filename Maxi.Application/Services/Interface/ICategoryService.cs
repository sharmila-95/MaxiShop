using Maxi.Application.DTO.Category;


namespace Maxi.Application.Services.Interface
{
    public interface ICategoryService
    {

        Task<CategoryDto> GetByIdAsync(int id);

        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(int id);
    }
}
