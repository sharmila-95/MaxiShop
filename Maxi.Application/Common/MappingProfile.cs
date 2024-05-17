﻿using AutoMapper;
using Maxi.Application.DTO.Brand;
using Maxi.Application.DTO.Category;
using Maxi.Domain;


namespace Maxi.Application.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap(); 
            CreateMap<Category,CreateCategoryDto>().ReverseMap();

            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
        }
    }
}
