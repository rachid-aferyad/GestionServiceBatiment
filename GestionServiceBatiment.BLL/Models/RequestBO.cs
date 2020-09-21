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
        public UserBO Creator { get; set; }

        public int CategoryId { get; set; }
        public CategoryBO Category { get; set; }

        public IEnumerable<CommentBO> Comments { get; set; }

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
