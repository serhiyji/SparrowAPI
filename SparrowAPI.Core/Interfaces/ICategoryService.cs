using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparrowAPI.Core.DTOs.Category;
using SparrowAPI.Core.Services;

namespace SparrowAPI.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task<ServiceResponse> GetByName(CategoryDto model);
        Task Create(CategoryDto model);
        Task Update(CategoryDto model);
        Task Delete(int id);
        Task<bool> IsNameCategoryInAllCategories(string NameCategory);
    }
}
