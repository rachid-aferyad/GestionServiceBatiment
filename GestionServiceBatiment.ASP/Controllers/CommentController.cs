using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using GestionServiceBatiment.ASP.Mappers;
using GestionServiceBatiment.ASP.Models;
using GestionServiceBatiment.ASP.Models.Comments;

namespace GestionServiceBatiment.ASP.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View(_commentService.GetAll().Select(s => s.MapTo<DisplayComment>()));
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View(_commentService.GetById(id).MapTo<DisplayComment>());
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View(new CreateCommentForm());
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CreateCommentForm commentForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _commentService.Post(commentForm.MapTo<Comment>());
                    return RedirectToAction("Index");
                }

                return View(commentForm);
            }
            catch
            {
                return View(commentForm);
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            Comment comment = _commentService.GetById(id);
            if(comment is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(comment.MapTo<UpdateCommentForm>());
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateCommentForm updateCommentForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _commentService.Put(id, updateCommentForm.MapTo<Comment>());
                    return RedirectToAction(nameof(Index));
                }

                return View(updateCommentForm);
            }
            catch
            {
                return View(updateCommentForm);
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _commentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetComments(EntityType entityType, int entityId)
        {
            return View(_commentService.GetComments(entityType, entityId).Select(s => s.MapTo<DisplayComment>()));
        }
    }
}
