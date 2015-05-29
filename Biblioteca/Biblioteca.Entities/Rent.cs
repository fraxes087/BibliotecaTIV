using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities
{
    public class Rent
    {
        public int id_rent { get; set; }
        public RentState state { get; set; }
        public User user { get; set; }
        public Book book { get; set; }
        public DateTime? ren_date { get; set; }
        public DateTime? ret_date { get; set; }
        public DateTime? res_date { get; set; }


        public Rent()
        {
            this.id_rent = 0;
            this.state = new RentState();
            this.user = new User();
            this.book = new Book();
            this.res_date = DateTime.Now;
            this.ren_date = null;
            this.ret_date = null;

        }
        public Rent(int id, RentState state, User user, Book book, DateTime? ren_date, DateTime? ret_date, DateTime? res_date)
        {
            this.id_rent = id;
            this.state = state;
            this.user = user;
            this.book = book;
            this.ren_date = ren_date;
            this.ret_date = ret_date;
            this.res_date = res_date;
        }
    }
}
