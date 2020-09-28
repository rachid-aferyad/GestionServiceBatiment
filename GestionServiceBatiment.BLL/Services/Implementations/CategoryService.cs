using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IServiceRepository _serviceRepository;
        //private readonly ICategoryService _categoryService;
        //private readonly ICompanyService _companyService;
        //private readonly ICommentService _commentService;
        private readonly IMappersService _mappersService;


        public CategoryService(ICategoryRepository categoryRepository,
            IMappersService mappersService
            )
        {
            _categoryRepository = categoryRepository;
            _mappersService = mappersService;
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<CategoryBO> GetAll()
        {
            return _categoryRepository.GetAll().Select(c => _mappersService.Map<Category, CategoryBO>(c));
        }

        public IEnumerable<CategoryBO> GetSup()
        {
            return _categoryRepository.GetSup().Select(c => _mappersService.Map<VCategoryListing, CategoryBO>(c));
        }

        public IEnumerable<CategoryBO> GetTop()
        {
            return _categoryRepository.GetTop().Select(c => _mappersService.Map<VCategoryListing, CategoryBO>(c));
        }

        public IEnumerable<CategoryBO> GetSub(int categoryId)
        {
            return _categoryRepository.GetSub(categoryId).Select(c => _mappersService.Map<VCategoryListing, CategoryBO>(c));
        }

        public IEnumerable<CategoryBO> GetSubByParentName(string parentName)
        {
            return _categoryRepository.GetSubByParentName(parentName).Select(c => _mappersService.Map<VCategoryListing, CategoryBO>(c));
        }

        public CategoryBO GetById(int id)
        {
            CategoryBO categoryBO = _mappersService.Map<Category, CategoryBO>(_categoryRepository.GetById(id));
            CategoryBO parent = null;
            if (categoryBO.ParentId != null)
                parent = _mappersService.Map<Category, CategoryBO>(_categoryRepository.GetById((int)categoryBO.ParentId));
            return categoryBO;
        }

        public CategoryBO GetByName(string name)
        {
            return _mappersService.Map<VCategoryDetails, CategoryBO>(_categoryRepository.GetByName(name));
        }

        public int Insert(CategoryBO entity)
        {
            return _categoryRepository.Insert(_mappersService.Map<CategoryBO, Category>(entity));
        }

        public bool Update(int id, CategoryBO entity)
        {
            Category category = _mappersService.Map<CategoryBO, Category>(entity);
            category.Id = id;
            return _categoryRepository.Update(category);
        }
    }
}
