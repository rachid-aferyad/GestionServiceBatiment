using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Models.Requests;
using GestionServiceBatiment.ASP.Models.Services;
using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Mappers;

namespace GestionServiceBatiment.ASP.Mappers
{
    public class MapperASP : MappersService
    {
        //private readonly IUserService _userService;

        //public MapperASP(IUserService userService)
        //{
        //    _userService = userService;
        //}
        protected override void ConfigureMappers(IMappersService service)
        {
            service.Register<Comment, DisplayComment>((s) => new DisplayComment()
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
                Creator = this.Map<User, DisplayUser>(s.Creator)
            });
            service.Register<Company, DisplayCompany>((s) => new DisplayCompany()
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
                Contractor = this.Map<User, DisplayUser>(s.Contractor)
            });
            service.Register<Service, DisplayService>((s) => new DisplayService()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CreationDate = s.CreationDate,
                Category = this.Map<Category, DisplayCategory>(s.Category),
                Company = this.Map<Company, DisplayCompany>(s.Company),
                Comments = s.Comments.Select(c => this.Map<Comment, DisplayComment>(c))
            });
            service.Register<Request, DisplayRequest>((s) => new DisplayRequest()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CreationDate = s.CreationDate,
                Category = this.Map<Category, DisplayCategory>(s.Category),
                Creator = this.Map<User, DisplayUser>(s.Creator),
                Comments = s.Comments.Select(c => this.Map<Comment, DisplayComment>(c))
            }) ;
            
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
            

            //service.Register<Category, CategoryBO>((s) => new CategoryBO()
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Description = s.Description,
            //    ParentId = s.ParentId
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
