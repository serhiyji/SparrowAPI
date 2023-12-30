using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparrowAPI.Core.DTOs.Category;
using SparrowAPI.Core.Interfaces;
using SparrowAPI.Core.Entities;
using SparrowAPI.Core.Entities.Specifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;

namespace SparrowAPI.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryService(IMapper mapper, IRepository<Category> categoryRepo, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this._mapper = mapper;
            this._categoryRepo = categoryRepo;
            this._webHostEnvironment = webHostEnvironment;
            this._configuration = configuration;
        }

        public async Task Create(CreateCategoryDto model)
        {
            if (model.Image != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string uploadPath = webRootPath + _configuration.GetValue<string>("ImageSettings:ImagePathCategories");
                string fileName = Guid.NewGuid().ToString();
                string extansion = Path.GetExtension(model.Image.FileName);
                string originalFilePath = Path.Combine(uploadPath, fileName + extansion);
                using (FileStream fileStream = new FileStream(originalFilePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                List<int> sizes = new List<int> { 50, 150, 300, 600, 1200 };
                foreach (int size in sizes)
                {
                    string resizedFileName = size + "_" + fileName;
                    string resizedFilePath = Path.Combine(uploadPath, resizedFileName + extansion);
                    using (var image = SixLabors.ImageSharp.Image.Load(originalFilePath))
                    {
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(size, 0),
                            Mode = ResizeMode.Max
                        }));
                        await image.SaveAsync(resizedFilePath);
                    }
                }

                model.ImagePath = fileName + extansion;
            }
            else
            {
                model.ImagePath = "Default.png";
            }
            await _categoryRepo.Insert(_mapper.Map<Category>(model));
            await _categoryRepo.Save();
        }

        public async Task Delete(int id)
        {
            CategoryDto? model = await Get(id);
            if (model == null) return;

            string webPathRoot = _webHostEnvironment.WebRootPath;
            string upload = webPathRoot + _configuration.GetValue<string>("ImageSettings:ImagePathCategories");
            string existingFilePath = Path.Combine(upload, model.ImagePath);
            if (File.Exists(existingFilePath) && model.ImagePath != "Default.png")
            {
                File.Delete(existingFilePath);
            }

            List<int> sizes = new List<int> { 50, 150, 300, 600, 1200 };
            foreach (int size in sizes)
            {
                string resizedFileName = size + "_" + Path.GetFileNameWithoutExtension(model.ImagePath);
                string resizedFilePath = Path.Combine(upload, resizedFileName + Path.GetExtension(model.ImagePath));
                if (File.Exists(resizedFilePath))
                {
                    File.Delete(resizedFilePath);
                }
            }

            await _categoryRepo.Delete(id);
            await _categoryRepo.Save();
        }

        public async Task<CategoryDto?> Get(int id)
        {
            if (id < 0) return null;
            Category? category = await _categoryRepo.GetByID(id);
            if(category == null) return null;
            return _mapper.Map<CategoryDto?>(category);
        }

        public async Task<ServiceResponse> GetByName(CategoryDto model)
        {
            var result = await _categoryRepo.GetItemBySpec(new CategorySpecification.GetByName(model.Name));
            if (result != null)
            {
                return new ServiceResponse(false, "Category exists.");
            }
            var category = _mapper.Map<CategoryDto>(result);
            return new ServiceResponse(true, "Category successfully loaded.", payload: category);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var result = await _categoryRepo.GetAll();
            return _mapper.Map<List<CategoryDto>>(result);
        }

        public async Task Update(UpdateCategoryDto model)
        {
            await _categoryRepo.Update(_mapper.Map<Category>(model));
            await _categoryRepo.Save();
        }

        public async Task<bool> IsNameCategoryInAllCategories(string NameCategory)
        {
            return (await this.GetAll()).Where(c => c.Name == NameCategory).Any();
        }
    }
}
