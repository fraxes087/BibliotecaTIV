using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca.UserInterface.Helpers;
using Biblioteca.UserInterface.Models;

namespace Biblioteca.UserInterface.Controllers
{
    public class RentController : Controller
    {
        private BusinessLogic.RentManager rentManager;
        private BusinessLogic.BookManager bookManager;
        public RentController(){
            this.rentManager = new BusinessLogic.RentManager();
            this.bookManager = new BusinessLogic.BookManager();
        }
        
        //
        // GET: /Rent/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            List<Rent> rentList = new List<Rent>();
            Helper helper = new Helper();
            foreach (var curRent in this.rentManager.getAllRents()) { 
                rentList.Add(helper.EntitiesToModel(curRent));
            }
            return View(rentList);
        }


        public ActionResult Create(int bookId, DateTime res_date ) {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            Helper helper = new Helper();
            Rent newRent = new Rent();
            newRent.book.id_book = bookId;
            newRent.res_date = res_date;
            newRent.user.username = User.Identity.Name;
            if (this.rentManager.reserveBook(helper.ModelToEntities(newRent)))
            {
                return RedirectToAction("Index", "Rent");
            }
            else {
                ViewBag.ErrorMessage = "You can't reserve that book";
            }


            return RedirectToAction("Index", "Rent");
        }

        public ActionResult Cancel(int id) {
            //TODO: hacer el cancel de una renta
            return RedirectToAction("Index","Rent");
        }

    }
}
