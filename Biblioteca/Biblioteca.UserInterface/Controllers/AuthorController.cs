using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.UserInterface.Helpers;
using Biblioteca.UserInterface.Models;

namespace Biblioteca.UserInterface.Controllers
{
    public class AuthorController : Controller
    {
        #region Field
        private BusinessLogic.AuthorManager authorManager;
        public AuthorController(){
            this.authorManager = new BusinessLogic.AuthorManager();
        }
        #endregion
        //
        // GET: /Author/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            List<Author> authorList = new List<Author>();
            List<Entities.Author> entAuthor = new List<Entities.Author>();
            Helper helper = new Helper();
            entAuthor = authorManager.AuthorsGetAll();
            foreach (var curAuthor in entAuthor)
            {
                authorList.Add(helper.EntitiesToModel(curAuthor));
            }

            return View(authorList);
        }

        //
        // GET: /Author/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
                        return View();
        }

        //
        // POST: /Author/Create

        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here
                if(author != null){
                    Helper helper = new Helper();
                    if (!authorManager.setNewAuthor(helper.ModelToEntities(author)))
                    {
                        return RedirectToAction("Index","Author");        
                    }

                    return RedirectToAction("Index");
                }
                ViewBag.ErrMessage("Please insert data to create a new author");
                return View();
            }
            catch
            {
                ViewBag.ErrMessage("Error con la carga");
                return View();
            }
            
        }

        //
        // GET: /Author/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Author/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Author/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Author/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
