﻿using Maxi.Application.DTO.Brand;
using Maxi.Application.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.Services.Interface
{
    public interface IBrandService
    {
        Task<BrandDto> GetByIdAsync(int id);

        Task<IEnumerable<BrandDto>> GetAllAsync();

        Task<BrandDto> CreateAsync(CreateBrandDto createbrandDto);
        Task UpdateAsync(UpdateBrandDto updatebrandDto);
        Task DeleteAsync(int id);
    }
}
