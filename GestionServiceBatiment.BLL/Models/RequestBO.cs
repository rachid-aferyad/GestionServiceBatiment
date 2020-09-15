using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class RequestBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        private UserBO _creator;
        public UserBO Creator
        {
            get
            {
                if (_creator is null)
                {
                    _creator = _userService.GetById((int)CreatorId);
                }
                return _creator;
            }
            set
            {
                Creator = value;
            }
        }

        public int? CategoryId { get; set; }
        //public string CategoryName { get { return Category.Name; } set { CategoryName = value; } }
        private CategoryBO _category;
        public CategoryBO Category
        {
            get
            {
                if (_category is null)
                {
                    if (!(CategoryId is null))
                    {
                        _category = _categoryService.GetById((int)CategoryId);
                    }
                    else _category = null;
                }
                return _category;
            }
            set
            {
                Category = value;
            }
        }

        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        public RequestBO(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }
        public RequestBO()
        {

        }
    }
}
