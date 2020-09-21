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

namespace TestMappers
{
    public class Mappers : MappersService
    {
        protected override void ConfigureMappers(IMappersService service)
        {
            // ASP <=> ASP

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
                RequestId = s.RequestId
            });
            service.Register<DisplayComment, Comment>((s) => new Comment()
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

            service.Register<Category, DisplayCategory>((s) => new DisplayCategory()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId,
                NavigationName = s.NavigationName
            });
            service.Register<DisplayCategory, Category>((s) => new Category()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId,
                NavigationName = s.NavigationName
            }) ;
            
            //service.Register<DisplayService, Service>((s) => new Service(){
            //    Id = s.Id, 
            //    Title = s.Title, 
            //    Description = s.Description, 
            //    ImageURI = s.ImageURI,
            //    CategoryId = s.CategoryId,
            //    CompanyId = s.CompanyId,
            //    CreationDate = s.CreationDate,
            //    ValidationDate = s.ValidationDate,
            //    ValidatorId = s.ValidatorId
            //});
            service.Register<Service, DisplayService>((s) => new DisplayService()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CreationDate = s.CreationDate,
                Category = this.Map<Category, DisplayCategory>(s.Category),
                Company = this.Map<Company, DisplayCompany>(s.Company),
                Comments = this.Map<IEnumerable<Comment>, IEnumerable<DisplayComment>>(s.Comments)
            });

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
            service.Register<Request, DisplayRequest>((s) => new DisplayRequest()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CreationDate = s.CreationDate,
                Category = this.Map<Category, DisplayCategory>(s.Category),
                Creator = this.Map<User, DisplayUser>(s.Creator),
                Comments = this.Map<IEnumerable<Comment>, IEnumerable<DisplayComment>>(s.Comments)
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
            service.Register<User, DisplayUser>((s) => new DisplayUser()
            {
                Id = s.Id,
                Login = s.Login,
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Active = s.Active,
                Role = s.Role
            });
        }
    }
}
