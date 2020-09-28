using GestionServiceBatiment.BLL.Services.Interfaces;
using GestionServiceBatiment.BLL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionServiceBatiment.BLL.Models;
using GestionServiceBatiment.API.Models.Companies;
using Tools.Mappers;

namespace GestionServiceBatiment.API.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMappersService _mappersService;

        public CompanyController(ICompanyService companyService, IMappersService mappersService)
        {
            _companyService = companyService;
            _mappersService = mappersService;
        }

        // GET: api/Company
        public IEnumerable<CompanyListing> Get()
        {
            return _companyService.GetAll().Select(c => _mappersService.Map<CompanyBO, CompanyListing>(c));
        }

        // GET: api/Company/5
        public DisplayCompany Get(int id)
        {
            return _mappersService.Map<CompanyBO, DisplayCompany>(_companyService.GetById(id));
        }

        [Route("api/Company/MostRatedProviders")]
        public IEnumerable<CompanyListing> GetMostRatedProviders()
        {
            return _companyService.GetMostRatedProviders().Select(c => _mappersService.Map<CompanyBO, CompanyListing>(c));
        }

        // POST: api/Company
        public HttpResponseMessage Post(CreateCompanyForm createCompanyForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _companyService.Insert(_mappersService.Map<CreateCompanyForm, CompanyBO>(createCompanyForm));
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Company/5
        public HttpResponseMessage Put(int id, UpdateCompanyForm updateCompanyForm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                _companyService.Update(id, _mappersService.Map<UpdateCompanyForm, CompanyBO>(updateCompanyForm));

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Company/5
        public HttpResponseMessage Delete(int id)
        {
            _companyService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
