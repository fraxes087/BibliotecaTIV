using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class Stock
    {
        public int id_stock { get; set; }
        public Book book { get; set; }
        public decimal cant { get; set; }

        public Stock() {
            this.id_stock = 0;
            this.book = new Book();
            this.cant = 0;
        }
        public Stock(int id, Book book, decimal cant) {
            this.id_stock = id;
            this.book = book;
            this.cant = cant;
        }
    }
}