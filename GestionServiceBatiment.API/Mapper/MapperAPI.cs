using GestionServiceBatiment.API.Models.Categories;
using GestionServiceBatiment.API.Models.Comments;
using GestionServiceBatiment.API.Models.Companies;
using GestionServiceBatiment.API.Models.Requests;
using GestionServiceBatiment.API.Models.Services;
using GestionServiceBatiment.API.Models.Users;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.DAL.Views.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tools.Mappers;
using D = GestionServiceBatiment.DAL.Models;
using DVS = GestionServiceBatiment.DAL.Views.Services;
using DVR = GestionServiceBatiment.DAL.Views.Requests;
using DVC = GestionServiceBatiment.DAL.Views.Comments;

namespace GestionServiceBatiment.API.Mappers
{
    public class MapperAPI : MappersService
    {
        protected override void ConfigureMappers(IMappersService service)
        {
            // DAL <=> DB

            // BLL <=> DAL
            service.Register<DVS.VServiceDetails, ServiceBO>((s) => new ServiceBO()
            {
                Id = s.Id,
                Title = s.Title,
                CreationDate = s.CreationDate,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                Category = new CategoryBO()
                {
                    Id = s.CategoryId,
                    Name = s.CategoryName,
                    Description = s.CategoryDescription,
                    ParentId = s.CategoryParentId,
                    Parent = (s.CategoryParentId is null) ? null : new CategoryBO()
                    {
                        Id = (int)s.CategoryParentId,
                        Name = s.CategoryParentName,
                        Description = s.CategoryParentDescription
                    }
                },
                CompanyId = s.CompanyId,
                Company = new CompanyBO()
                {
                    Id = s.CompanyId,
                    Name = s.CompanyName,
                    VatNumber = s.CompanyVatNumber,
                    AddressStreet = s.CompanyAddressStreet,
                    AddressNumber = s.CompanyAddressNumber,
                    AddressMailBox = s.CompanyAddressMailBox,
                    AddressZipCode = s.CompanyAddressZipCode,
                    AddressCity = s.CompanyAddressCity,
                    AddressCountry = s.CompanyAddressCountry,
                    ContractorId = s.ContractorId,
                    Contractor = new UserBO()
                    {
                        Id = s.ContractorId,
                        Login = s.ContractorLogin,
                        Email = s.ContractorEmail,
                        FirstName = s.ContractorFirstName,
                        LastName = s.ContractorLastName,
                        BirthDate = s.ContractorBirthDate
                    }
                }
            });
            service.Register<DVS.VServiceListing, ServiceBO>((s) => new ServiceBO()
            {
                Id = s.Id,
                Title = s.Title,
                CreationDate = s.CreationDate,
                Description = s.Description,
                ImageURI = s.ImageURI,
                Category = new CategoryBO()
                {
                    Id = s.CategoryId,
                    Name = s.CategoryName
                },
                Company = new CompanyBO()
                {
                    Id = s.CompanyId,
                    Name = s.CompanyName
                }
            });

            service.Register<DVR.VRequestDetails, RequestBO>((s) => new RequestBO()
            {
                Id = s.Id,
                Title = s.Title,
                CreationDate = s.CreationDate,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.CategoryId,
                Category = new CategoryBO()
                {
                    Id = s.CategoryId,
                    Name = s.CategoryName,
                    Description = s.CategoryDescription,
                    ParentId = s.CategoryParentId,
                    Parent = (s.CategoryParentId is null) ? null : new CategoryBO()
                    {
                        Id = (int)s.CategoryParentId,
                        Name = s.CategoryParentName,
                        Description = s.CategoryParentDescription
                    }
                },
                CreatorId = s.CreatorId,
                Creator = new UserBO()
                {
                    Id = s.CreatorId,
                    Login = s.CreatorLogin,
                    Email = s.CreatorEmail,
                    FirstName = s.CreatorFirstName,
                    LastName = s.CreatorLastName,
                    BirthDate = s.CreatorBirthDate
                }
            });
            service.Register<DVR.VRequestListing, RequestBO>((s) => new RequestBO()
            {
                Id = s.Id,
                Title = s.Title,
                CreationDate = s.CreationDate,
                Description = s.Description,
                ImageURI = s.ImageURI,
                Category = new CategoryBO()
                {
                    Id = s.CategoryId,
                    Name = s.CategoryName
                },
                Creator = new UserBO()
                {
                    Id = s.CreatorId,
                    FirstName = s.CreatorFirstName,
                    LastName = s.CreatorLastName
                }
            });

            service.Register<DVC.VComment, CommentBO>((s) => new CommentBO()
            {
                Id = s.Id,
                Content = s.Content,
                Star = s.Star,
                CreationDate = s.CreationDate,
                CompanyId = s.CompanyId,
                ServiceId = s.ServiceId,
                RequestId = s.RequestId,
                ParentId = s.ParentId,
                CreatorId = s.CreatorId,
                Creator = new UserBO()
                {
                    Id = s.CreatorId,
                    Login = s.Login,
                    Email = s.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }
            });


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
                Creator = s.Creator == null ? null : this.Map<UserBO, DisplayUser>(s.Creator)
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
                Category = s.Category == null ? null : this.Map<CategoryBO, DisplayCategory>(s.Category),
                Company = s.Company == null ? null : this.Map<CompanyBO, DisplayCompany>(s.Company),
                Comments = s.Comments == null ? null : s.Comments.Select(c => this.Map<CommentBO, DisplayComment>(c))
            });
            service.Register<ServiceBO, ServiceListing>((s) => new ServiceListing()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryId = s.Category.Id,
                CategoryName = s.Category.Name,
                CompanyId = s.Company.Id,
                CompanyName = s.Company.Name,
                CreationDate = s.CreationDate,
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
            service.Register<RequestBO, RequestListing>((s) => new RequestListing()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageURI = s.ImageURI,
                CategoryName = s.Category.Name,
                CreatorName = s.Creator.FirstName + " " + s.Creator.LastName,
                CreationDate = s.CreationDate,
            });


            service.Register<CategoryBO, DisplayCategory>((s) => new DisplayCategory()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ParentId = s.ParentId,
                Parent = s.Parent != null ? this.Map<CategoryBO, DisplayCategory>(s.Parent) : null
            });
        
            
        
        
        
        }
    }
}
