using GestionServiceBatiment.BLL.Mappers;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<CategoryBO> GetAll()
        {
            return _categoryRepository.GetAll().Select(c => c.MapTo<CategoryBO>());
        }

        public IEnumerable<CategoryBO> GetSup()
        {
            return _categoryRepository.GetSup().Select(c => c.MapTo<CategoryBO>());
        }

        public IEnumerable<CategoryBO> GetSub(int categoryId)
        {
            return _categoryRepository.GetSub(categoryId).Select(c => c.MapTo<CategoryBO>());
        }

        public IEnumerable<CategoryBO> GetSubByParentName(string parentName)
        {
            return _categoryRepository.GetSubByParentName(parentName).Select(c => c.MapTo<CategoryBO>());
        }

        public CategoryBO GetById(int id)
        {
            return _categoryRepository.GetById(id).MapTo<CategoryBO>();
        }

        public CategoryBO GetByName(string name)
        {
            return _categoryRepository.GetByName(name).MapTo<CategoryBO>();
        }

        public int Insert(CategoryBO entity)
        {
            return _categoryRepository.Insert(entity.MapTo<Category>());
        }

        public bool Update(int id, CategoryBO entity)
        {
            Category category = entity.MapTo<Category>();
            category.Id = id;
            return _categoryRepository.Update(category);
        }
    }
}
