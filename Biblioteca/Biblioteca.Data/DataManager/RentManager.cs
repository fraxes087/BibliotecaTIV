using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class RentManager : BiblioDbManager
    {
        public RentManager() : base() { }

        public List<Entities.Rent> getAllRents() {
            List<Entities.Rent> entRentList = new List<Entities.Rent>();
            var rentList = this.db.Set<Rents>().ToList();
            foreach (var curDbRent in rentList) {
                var rentState = this.db.Set<Rent_States>().Where(x => x.id_state == curDbRent.id_state).FirstOrDefault();
                var user = this.db.Set<Users>().Where(x => x.id_user == curDbRent.id_user).FirstOrDefault();
                var book = this.db.Set<Books>().Where(x => x.id_book == curDbRent.id_book).FirstOrDefault();
#region Valido la fecha para cancelar las rentas que no fueron retiradas en mas de 2 dias
                DateTime returnDate = curDbRent.res_date != null ? (System.DateTime)curDbRent.res_date : System.DateTime.MinValue;
                DateTime now = System.DateTime.Now;

                if (now >= returnDate.AddDays(2) && curDbRent.ret_date == null && rentState.description == "RESERVED")
                {
                    rentState = this.db.Set<Rent_States>().Where(x => x.description == "CANCELLED").FirstOrDefault();
                    curDbRent.id_state = rentState.id_state;
                    curDbRent.ret_date = System.DateTime.Now;
                    book.stock += 1;
                    this.db.SaveChanges();
                }
#endregion
                
                if (rentState != null && user != null && book != null)
                {
                    Entities.RentState entRentState = new Entities.RentState();
                    entRentState.id_state = rentState.id_state;
                    entRentState.description = rentState.description;

                    Entities.User entUser = new Entities.User();
                    entUser.id_user = user.id_user;
                    entUser.username = user.username;
                    entUser.first_name = user.first_name;
                    entUser.last_name = user.last_name;

                    var dbGender = this.db.Set<Genders>().Where(x => x.id_gender == user.id_gender).FirstOrDefault();
                    entUser.gender.id_gender = user.id_gender;
                    entUser.gender.description = dbGender.description;

                    var role = this.db.Set<UserRoles>().Where(x => x.id_role == user.id_role).FirstOrDefault();
                    entUser.role.Id_userRole = role.id_role;
                    entUser.role.description = role.description;

                    entUser.birthDate = user.birthDate;

                    Entities.Book entBook = new Entities.Book();
                    entBook.id_book = book.id_book;
                    entBook.title = book.titulo;
                    entBook.authorName = book.Authors.first_name;
                    entBook.authorLastName = book.Authors.last_name;
                    entBook.publisher = book.Publishers.full_name;
                    entBook.stock = book.stock;
                    entBook.genre = book.Genres.description;

                    entRentList.Add(new Entities.Rent(
                                                        curDbRent.id_rent,
                                                        entRentState,
                                                        entUser,
                                                        entBook,
                                                        curDbRent.ren_date,
                                                        curDbRent.ret_date,
                                                        curDbRent.res_date
                                                        ));
                }
            }
            return entRentList;
            
        }

        public bool reserveBook(Entities.Rent entRent)
        {

            Rents dbRent = new Rents();
            dbRent.id_state = this.db.Set<Rent_States>().Where(x => x.description == "RESERVED").FirstOrDefault().id_state;
            dbRent.id_user = this.db.Set<Users>().Where(x => x.username == entRent.user.username).FirstOrDefault().id_user;
            //valido que el usuario no tenga alquilado y/o reservado un libro.
            var user = this.db.Set<Rents>().Where(x => x.id_user == dbRent.id_user && (x.ret_date != null || x.Rent_States.description != "CANCELLED")).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            
            //Valido que el libro tenga stock
            Books dbBook = this.db.Set<Books>().Where(x => x.id_book == entRent.book.id_book).FirstOrDefault();
            if (dbBook.stock <= 0) {
                return false;
            } 
            dbBook.stock -= 1;
            dbRent.id_book = entRent.book.id_book;
            dbRent.ren_date = entRent.ren_date;
            dbRent.res_date = entRent.res_date;
            dbRent.ret_date = entRent.ret_date;

            this.db.Rents.Add(dbRent);
            this.db.SaveChanges();

            return true;
        }

        
    }
}
