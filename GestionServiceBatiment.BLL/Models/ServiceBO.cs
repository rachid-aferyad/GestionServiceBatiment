using GestionServiceBatiment.BLL.Services.Implementations;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Models
{
    public class ServiceBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURI { get; set; }
        public bool Active { get; set; }
        public bool ActivedForValidation { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ValidationDate { get; set; }
        
        public int CompanyId { get; set; }
        //private CompanyBO _company;
        public CompanyBO Company { get; set; }
        //{
        //    get
        //    {
        //        return _companyService.GetById(CompanyId);
        //    }
        //    set
        //    {
        //        _company = value;
        //    } 
        //}

        public int? ValidatorId { get; set; }
        //private UserBO _validator;

        public UserBO Validator { get; set; }
        //{
        //    get { 
        //        if(ValidatorId is null)
        //        {
        //            _validator = null;
        //        }
        //        else
        //        {
        //            _validator = _userService.GetById((int)ValidatorId);
        //        }
        //        return _validator;
        //    }
        //    set { 
        //        _validator = value; 
        //    }
        //}

        public int CategoryId { get; set; }
        //private CategoryBO _category;
        public CategoryBO Category { get; set; }
        //{
        //    get
        //    {
        //        return _categoryService.GetById(CategoryId);
        //    }
        //    set
        //    {
        //        _category = value;
        //    }
        //}

        public IEnumerable<CommentBO> Comments { get; set; }
        //{
        //    get
        //    {
        //        return _commentService.GetByService(Id);
        //    }
        //    //set
        //    //{
        //    //    _company = value;
        //    //}
        //}

        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        
        public ServiceBO(ICompanyService companyService, 
                         ICategoryService categoryService,
                         IUserService userService,
                         ICommentService commentService
            )
        {
            _companyService = companyService;
            _userService = userService;
            _categoryService = categoryService;
            _commentService = commentService;
        }
        public ServiceBO()
        {
        }
    }
}
