using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Mappers;

namespace GestionServiceBatiment.BLL.Mappers
{
    public class MapperBLL : MappersService
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public MapperBLL(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }
        protected override void ConfigureMappers(IMappersService service)
        {
            //BLL <=> DAL
            service.Register<Comment, CommentBO>((s) => new CommentBO(_userService)
            {
                Id = s.Id,
                Content = s.Content,
                CreationDate = s.CreationDate,
                Star = s.Star,
                ParentId = s.ParentId,
                CreatorId = s.CreatorId,
                CompanyId = s.CompanyId,
                ServiceId = s.ServiceId,
                RequestId = s.RequestId
                //Children = this.Map<IEnumerable<CommentBO>, IEnumerable<DisplayComment>>(s.Children),
                //Creator = this.Map<UserBO, DisplayUser>(s.Creator)
            });
            service.Register<CommentBO, Comment>((s) => new Comment()
            {
                Id = s.Id,
                Content = s.Content,
                CreationDate = s.CreationDate,
                Star = s.Star,
                ParentId = s.ParentId,
                CreatorId = s.CreatorId,
                CompanyId = s.CompanyId,
                ServiceId = s.ServiceId,
                RequestId = s.RequestId
            });
            
            service.Register<Category, CategoryBO>((s) => new CategoryBO(_categoryService)
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId
            });
            service.Register<CategoryBO, Category>((s) => new Category()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId
            });
            
           

            service.Register<Company, CompanyBO>((s) => new CompanyBO()
            {
                Id = s.Id,
                Name = s.Name,
                VatNumber = s.VatNumber,
                AddressStreet = s.AddressStreet,
                AddressNumber = s.AddressNumber,
                AddressMailBox = s.AddressMailBox,
                AddressZipCode = s.AddressZipCode,
                AddressCity = s.AddressCity,
                AddressCountry = s.AddressCountry,
                ContractorId = s.ContractorId
            });
            service.Register<CompanyBO, Company>((s) => new Company()
            {
                Id = s.Id,
                Name = s.Name,
                VatNumber = s.VatNumber,
                AddressStreet = s.AddressStreet,
                AddressNumber = s.AddressNumber,
                AddressMailBox = s.AddressMailBox,
                AddressZipCode = s.AddressZipCode,
                AddressCity = s.AddressCity,
                AddressCountry = s.AddressCountry,
                ContractorId = s.ContractorId
            });

            service.Register<Request, RequestBO>((s) => new RequestBO()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                CreatorId = s.CreatorId,
                CreationDate = s.CreationDate
            });
            service.Register<RequestBO, Request>((s) => new Request()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                CreatorId = s.CreatorId,
                CreationDate = s.CreationDate
            });

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
            service.Register<ServiceBO, Service>((s) => new Service()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                Active = s.Active,
                ActivedForValidation = s.ActivedForValidation,
                CategoryId = s.CategoryId,
                CompanyId = s.CompanyId,
                CreationDate = s.CreationDate,
                ValidationDate = s.ValidationDate,
                ValidatorId = s.ValidatorId
            });

            service.Register<User, UserBO>((s) => new UserBO()
            {
                Id = s.Id,
                Login = s.Login,
                Email = s.Email,
                Password = s.Password,
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Active = s.Active,
                Role = (s.Role == "ADMIN") ? UserRole.ADMIN : (s.Role == "CONTRACTOR") ? UserRole.CONTRACTOR : UserRole.USER_SIMPLE
            });
            service.Register<UserBO, User>((s) => new User()
            {
                Id = s.Id,
                Login = s.Login,
                Email = s.Email,
                Password = s.Password,
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Active = s.Active,
                Role = s.Role.ToString()
            });
        }
    }
}
