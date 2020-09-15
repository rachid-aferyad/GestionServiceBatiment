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
        
        public int? CompanyId { get; set; }
        private CompanyBO _company;
        public CompanyBO Company
        {
            get
            {
                if (_company is null)
                {
                    if (!(CompanyId is null))
                    {
                        _company = _companyService.GetById((int)CompanyId);
                    }
                    else _company = null;
                }
                return _company;
            }
            set
            {
                Company = value;
            }
        }

        public int? ValidatorId { get; set; }
        private UserBO _validator;
        public UserBO Validator
        {
            get
            {
                if (_validator is null)
                {
                    if (!(ValidatorId is null))
                    {
                        _validator = _userService.GetById((int)ValidatorId);
                    }
                    else _validator = null;
                }
                return _validator;
            }
            set
            {
                Validator = value;
            }
        }

        public int? CategoryId { get; set; }
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

        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        public ServiceBO(ICompanyService companyService, IUserService userService, ICategoryService categoryService)
        {
            _companyService = companyService;
            _userService = userService;
            _categoryService = categoryService;
        }
        public ServiceBO()
        {

        }
    }
}
