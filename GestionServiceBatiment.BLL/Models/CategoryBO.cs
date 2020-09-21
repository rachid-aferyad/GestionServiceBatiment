using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class CategoryBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int? ParentId { get; set; }
        //private CategoryBO _parent;
        public CategoryBO Parent { get; set; }
        //{
        //    get
        //    {
        //        if (_parent is null)
        //        {
        //            if (!(ParentId is null))
        //            {
        //                _parent = _categoryService.GetById((int)ParentId);
        //            }
        //            else _parent = null;
        //        }
        //        return _parent;
        //    }
        //    set
        //    {
        //        Parent = value;
        //    }
        //}

        private readonly ICategoryService _categoryService;
        public CategoryBO(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public CategoryBO()
        {

        }
    }
}
