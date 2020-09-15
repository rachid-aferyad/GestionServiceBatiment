using GestionServiceBatiment.BLL.Mappers;
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

namespace GestionServiceBatiment.API.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            return _companyService.GetAll().Select(c => c.MapTo<Company>());
        }

        // GET: api/Company/5
        public Company Get(int id)
        {
            return _companyService.GetById(id).MapTo<Company>();
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
                _companyService.Insert(createCompanyForm.MapTo<CompanyBO>());
                
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
                _companyService.Update(id, updateCompanyForm.MapTo<CompanyBO>());

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
