using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_userService.GetAll().Select(u => u.MapTo<DisplayUser>()));
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            DisplayUser displayUser = _userService.GetById(id).MapTo<DisplayUser>();
            if(displayUser is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(displayUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new CreateUserForm());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(CreateUserForm createUserForm)
        {
            if (ModelState.IsValid)
            {
                if (createUserForm.Password.Equals(createUserForm.ConfirmPassword))
                {
                    try
                    {
                        _userService.Post(createUserForm.MapTo<User>());
                        return RedirectToAction(nameof(Index));
                    }
                    catch(Exception ex)
                    {
                        ViewBag.Exception = ex.Message;
                        return View(createUserForm);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Veuillez confirmer votre mot de passe!");
                }
            }
            return View(createUserForm);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UpdateUserForm updateUserForm = _userService.GetById(id).MapTo<UpdateUserForm>();
            if(updateUserForm is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(updateUserForm);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateUserForm updateUserForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Put(id, updateUserForm.MapTo<User>());
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                    return View(updateUserForm);
                }
            }
            return View(updateUserForm);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Delete(id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                    return View(collection);
                }
            }
            return View(collection);
        }
    }
}
