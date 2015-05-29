using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.UserInterface.Helpers;
using Biblioteca.UserInterface.Models;

namespace Biblioteca.UserInterface.Controllers
{
    public class BookController : Controller
    {
        #region Field
        private BusinessLogic.BookManager bookManager;
        public BookController() {
            this.bookManager = new BusinessLogic.BookManager();
        }
        #endregion
        //
        // GET: /Book/

        public ActionResult Index()
        {
            try {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "User");
                }
                Helper helper = new Helper();
                List<Book> bookList = new List<Book>();
                foreach(var curBook in this.bookManager.getBookList()){
                    bookList.Add(helper.EntitiesToModel(curBook));
                }

                return View(bookList);
            }
            catch(Exception ex){
                ViewBag.error = ex.Message;
                return View();
            }

            
        }
        //
        // GET: /Book/Details/5

        public ActionResult Details(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            ViewBag.Error = "";
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "User");
                }
                if(newBook != null){
                    Helper helper = new Helper();
                    if (this.bookManager.setNewBook(helper.ModelToEntities(newBook))) {
                        return RedirectToAction("Index", "Book");
                    }
                    else
                    {
                        ViewBag.Error = "The book already exists";
                        return View(newBook);

                    }
                   


                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        //
        // POST: /Book/Edit/5

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
        // GET: /Book/Delete/5

        public ActionResult Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        //
        // POST: /Book/Delete/5

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
