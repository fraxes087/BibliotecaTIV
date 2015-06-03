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

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            try {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "User");
                }
                ViewBag.CurrentSort = sortOrder;

                if (page != null)
                {
                    page = 1;
                }
                else {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                Helper helper = new Helper();
                List<Book> bookList = new List<Book>();
                foreach (var curBook in this.bookManager.getBookList())
                {
                    bookList.Add(helper.EntitiesToModel(curBook));
                }
                if (!String.IsNullOrEmpty(searchString))
                {
                    bookList = bookList.Where(x => x.title.Contains(searchString) || x.publisher.Contains(searchString) || x.authorName.Contains(searchString) || x.authorLastName.Contains(searchString)).ToList();
                }
                
                
                switch (sortOrder)
                {
                    case "title_desc": 
                        bookList = bookList.OrderByDescending(x => x.title).ToList();
                        ViewBag.NameSortParam = "title_desc";
                        break;
                    case "publisher":
                        bookList = bookList.OrderByDescending(x => x.publisher).ToList();
                        ViewBag.NameSortParam = "publisher";
                        break;
                    case "publisher_desc":
                        bookList = bookList.OrderBy(x => x.publisher).ToList();
                        ViewBag.NameSortParam = "publisher_desc";
                        break;
                    case "authorName":
                        bookList = bookList.OrderByDescending(x => x.authorName).ToList();
                        ViewBag.NameSortParam = "authorName";
                        break;
                    case "authorName_desc":
                        bookList = bookList.OrderBy(x => x.authorName).ToList();
                        ViewBag.NameSortParam = "authorName_desc";
                        break;
                    case "authorLastName":
                        bookList = bookList.OrderByDescending(x => x.authorLastName).ToList();
                        ViewBag.NameSortParam = "authorLastName";
                        break;
                    case "authorLastName_desc":
                        bookList = bookList.OrderBy(x => x.authorLastName).ToList();
                        ViewBag.NameSortParam = "authorLastName_desc";
                        break;
                    case "stock":
                        bookList = bookList.OrderBy(x => x.stock).ToList();
                        ViewBag.NameStortParam = "stock";
                        break;
                    case "stock_desc":
                        bookList = bookList.OrderByDescending(x => x.stock).ToList();
                        ViewBag.NameSortParam = "stock_desc";
                        break;
                    default: 
                        bookList =  bookList.OrderBy(x => x.title).ToList();
                        ViewBag.NameSortParam = "title";
                        break;

                }

                int pageSize = 3;
                int pageNumber = (page ?? 1);
                return View(bookList.ToPagedList(pageNumber, pageSize));
            }
            catch(Exception ex){
                ViewBag.error = ex.Message;
                return View();
            }
        }


        //[HttpPost]
        //public ActionResult Index() {
        //    try {
        //        List<Book> bookList = new List<Book>();
        //        Helper helper = new Helper();
        //        if(!String.IsNullOrEmpty(searchString)){
        //        //foreach (var curBook in this.bookManager.searchBy(searchDesc)) {
        //        //    bookList.Add(helper.EntitiesToModel(curBook));
        //        //}
        //        }else{
        //            foreach(var curBook in this.bookManager.getBookList()){
        //               bookList.Add(helper.EntitiesToModel(curBook));
        //            }
        //        }
        //        var sortOrder = !string.IsNullOrEmpty(currentFilter) ? currentFilter : "";
        //        switch(sortOrder)
        //        {
        //            case "title_desc": bookList.OrderByDescending(x => x.title);
        //                break;
        //            default: bookList.OrderBy(x => x.title);
        //                break;

        //        }

        //        return View(bookList);
        //    }
        //    catch (Exception ex) { 
        //        ViewBag.Error = "Error: " + ex.Message;
        //        return View();
        //    }
        //}
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
            catch(Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
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
