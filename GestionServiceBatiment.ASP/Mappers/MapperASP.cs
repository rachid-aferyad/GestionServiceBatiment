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
            });
            

        }
    }
}
