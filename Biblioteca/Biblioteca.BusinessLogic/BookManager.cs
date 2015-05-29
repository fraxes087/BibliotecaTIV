using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class BookManager
    {
        private Data.BookManager bookManager;
        public BookManager()
        {
            this.bookManager = new Data.BookManager();
        }

        public bool setNewBook(Entities.Book entBook)
        {
            try
            {
                return this.bookManager.setNewBook(entBook);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entities.Book> getBookList() {
            try 
            { 
                return this.bookManager.getBookList();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }


    }
}
