using AutoMapper;
using SparrowAPI.Core.DTOs.Category;
using SparrowAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.AutoMapper.Categories
{
    public class AutoMapperCategoryProfile : Profile
    {
        public AutoMapperCategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();
        }
    }
}
