using GestionServiceBatiment.API.Models.Categories;
using GestionServiceBatiment.API.Models.Comments;
using GestionServiceBatiment.API.Models.Companies;
using GestionServiceBatiment.API.Models.Requests;
using GestionServiceBatiment.API.Models.Services;
using GestionServiceBatiment.API.Models.Users;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Mappers;
using D = GestionServiceBatiment.DAL.Models;
using DV = GestionServiceBatiment.DAL.Views.Services;

namespace GestionServiceBatiment.API.Mappers
{
    public class MapperAPI : MappersService
    {
        //private readonly IUserService _userService;
        //private readonly ICompanyService _companyService;
        //private readonly ICategoryService _categoryService;
        //private readonly ICommentService _commentService;

        public MapperAPI(
                //IUserService userService, 
                //ICompanyService companyService, 
                ////ICategoryService categoryService,
                //ICommentService commentService
            )
        {
            //_userService = userService;
            //_companyService = companyService;
            ////_categoryService = categoryService;
            //_commentService = commentService;
        }
        protected override void ConfigureMappers(IMappersService service)
        {
            // BLL <=> DAL
            //service.Register<D.Comment, CommentBO>((s) => new CommentBO(_userService)
            //{
            //    Id = s.Id,
            //    Content = s.Content,
            //    CreationDate = s.CreationDate,
            //    Star = s.Star,
            //    ParentId = s.ParentId,
            //    CreatorId = s.CreatorId,
            //    CompanyId = s.CompanyId,
            //    ServiceId = s.ServiceId,
            //    RequestId = s.RequestId
            //    //Children = this.Map<IEnumerable<CommentBO>, IEnumerable<DisplayComment>>(s.Children),
            //    //Creator = this.Map<UserBO, DisplayUser>(s.Creator)
            //});
            //service.Register<D.Category, CategoryBO>((s) => new CategoryBO(_categoryService)
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Description = s.Description,
            //    ParentId = s.ParentId
            //    //Children = this.Map<IEnumerable<CommentBO>, IEnumerable<DisplayComment>>(s.Children),
            //    //Creator = this.Map<UserBO, DisplayUser>(s.Creator)
            //});

            //service.Register<D.Service, ServiceBO>((s) => new ServiceBO(
            //    )
            //{
            //    Id = s.Id,
            //    Title = s.Title,
            //    CreationDate = s.CreationDate,
            //    Description = s.Description,
            //    Active = s.Active,
            //    ActivedForValidation = s.ActivedForValidation,
            //    CompanyId = s.CompanyId,
            //    CategoryId = s.CategoryId,
            //    ImageURI = s.ImageURI,
            //    ValidatorId = s.ValidatorId,
            //    ValidationDate = s.ValidationDate
            //    //Children = this.Map<IEnumerable<CommentBO>, IEnumerable<DisplayComment>>(s.Children),
            //    //Creator = this.Map<UserBO, DisplayUser>(s.Creator)
            //});

            // API <=> BLL
            service.Register<CommentBO, DisplayComment>((s) => new DisplayComment()
            {
                Id = s.Id,
                Content = s.Content,
                CreationDate = s.CreationDate,
                Star = s.Star,
                ParentId = s.ParentId,
                CreatorId = s.CreatorId,
                CompanyId = s.CompanyId,
                ServiceId = s.ServiceId,
                RequestId = s.RequestId,
                //Children = this.Map<IEnumerable<CommentBO>, IEnumerable<DisplayComment>>(s.Children),
                Creator = s.Creator != null ? this.Map<UserBO, DisplayUser>(s.Creator) : null
            });
            service.Register<CompanyBO, DisplayCompany>((s) => new DisplayCompany()
            {
                Id = s.Id,
                Name = s.Name,
                VatNumber = s.VatNumber,
                ContractorId = s.ContractorId,
                AddressStreet = s.AddressStreet,
                AddressNumber = s.AddressNumber,
                AddressMailBox = s.AddressMailBox,
                AddressZipCode = s.AddressZipCode,
                AddressCity = s.AddressCity,
                AddressCountry = s.AddressCountry,
                Contractor = s.Contractor != null ? this.Map<UserBO, DisplayUser>(s.Contractor) : null
            });
            service.Register<ServiceBO, DisplayService>((s) => new DisplayService()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                CompanyId = s.CompanyId,
                CreationDate = s.CreationDate,
                Category = s.Category != null ? this.Map<CategoryBO, DisplayCategory>(s.Category) : null,
                Company = s.Company != null ? this.Map<CompanyBO, DisplayCompany>(s.Company) : null,
                Comments = s.Comments != null ? s.Comments.Select(c => c != null ? this.Map<CommentBO, DisplayComment>(c) : null) : null
            });
            service.Register<RequestBO, DisplayRequest>((s) => new DisplayRequest()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                CreatorId = s.CreatorId,
                CreationDate = s.CreationDate,
                Category = s.Category != null ? this.Map<CategoryBO, DisplayCategory>(s.Category) : null,
                Creator = s.Creator != null ? this.Map<UserBO, DisplayUser>(s.Creator) : null,
                Comments = s.Comments != null ? s.Comments.Select(c => c != null ? this.Map<CommentBO, DisplayComment>(c) : null) : null
            });
            service.Register<CategoryBO, DisplayCategory>((s) => new DisplayCategory()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId,
                Parent = s.Parent != null ? this.Map<CategoryBO, DisplayCategory>(s.Parent) : null
            });

            //service.Register<User, UserBO>((s) => new UserBO()
            //{
            //    Id = s.Id,
            //    Login = s.Login,
            //    Email = s.Email,
            //    Password = s.Password,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    BirthDate = s.BirthDate,
            //    Active = s.Active,
            //    Role = s.Role
            //});
            //service.Register<UserBO, DisplayUser>((s) => new DisplayUser()
            //{
            //    Id = s.Id,
            //    Login = s.Login,
            //    Email = s.Email,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    BirthDate = s.BirthDate,
            //    Active = s.Active,
            //    Role = s.Role
            //});

            //service.Register<Comment, CommentBO>((s) => new CommentBO()
            //{
            //    Id = s.Id,
            //    Content = s.Content,
            //    CreationDate = s.CreationDate,
            //    Star = s.Star,
            //    ParentId = s.ParentId,
            //    CreatorId = s.CreatorId,
            //    CompanyId = s.CompanyId,
            //    ServiceId = s.ServiceId,
            //    RequestId = s.RequestId
            //});


            //service.Register<CategoryBO, DisplayCategory>((s) => new DisplayCategory()
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Description = s.Description,
            //    ParentId = s.ParentId
            //});

            //service.Register<Company, CompanyBO>((s) => new CompanyBO()
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    VatNumber = s.VatNumber,
            //    ContractorId = s.ContractorId,
            //    AddressStreet = s.AddressStreet,
            //    AddressNumber = s.AddressNumber,
            //    AddressMailBox = s.AddressMailBox,
            //    AddressZipCode = s.AddressZipCode,
            //    AddressCity = s.AddressCity,
            //    AddressCountry = s.AddressCountry
            //});


            //service.Register<Service, ServiceBO>((s) => new ServiceBO(){
            //    Id = s.Id, 
            //    Title = s.Title, 
            //    Description = s.Description, 
            //    ImageURI = s.ImageURI,
            //    Active = s.Active,
            //    ActivedForValidation = s.ActivedForValidation,
            //    CategoryId = s.CategoryId,
            //    CompanyId = s.CompanyId,
            //    CreationDate = s.CreationDate,
            //    ValidationDate = s.ValidationDate,
            //    ValidatorId = s.ValidatorId
            //});


            //service.Register<Request, RequestBO>((s) => new RequestBO()
            //{
            //    Id = s.Id,
            //    Title = s.Title,
            //    Description = s.Description,
            //    ImageURI = s.ImageURI,
            //    CategoryId = s.CategoryId,
            //    CreatorId = s.CreatorId,
            //    CreationDate = s.CreationDate
            //});

            //service.Register<CommentBO, DisplayComment>((s) => new DisplayComment()
            //{
            //    Id = s.Id,
            //    Content = s.Content,
            //    Star = s.Star,
            //    ParentId = s.ParentId,
            //    CompanyId = s.CompanyId,
            //    CreatorId = s.CreatorId,
            //    CreationDate = s.CreationDate,
            //    ServiceId = s.ServiceId,
            //    RequestId = s.RequestId,
            //    Creator = this.Map<UserBO, DisplayUser>(s.Creator),
            //    Children = s.Children.Select(c => this.Map<CommentBO, DisplayComment>(c))
            //});

        }
    }
}
