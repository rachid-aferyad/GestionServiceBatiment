using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Companies;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        // GET: Company
        public ActionResult Index()
        {
            return View(_companyService.GetAll().Select(s => s.MapTo<DisplayCompany>()));
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            return View(_companyService.GetById(id).MapTo<DisplayCompany>());
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View(new CreateCompanyForm());
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CreateCompanyForm companyForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _companyService.Post(companyForm.MapTo<Company>());
                    return RedirectToAction("Index");
                }

                return View(companyForm);
            }
            catch
            {
                return View(companyForm);
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            Company company = _companyService.GetById(id);
            if(company is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(company.MapTo<UpdateCompanyForm>());
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateCompanyForm updateCompanyForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _companyService.Put(id, updateCompanyForm.MapTo<Company>());
                    return RedirectToAction(nameof(Index));
                }

                return View(updateCompanyForm);
            }
            catch
            {
                return View(updateCompanyForm);
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _companyService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
