using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class AuthorManager
    {
        private Data.AuthorManager authorManager;
        public AuthorManager() {
            this.authorManager = new Data.AuthorManager();
        }

        public bool setNewAuthor(Entities.Author entAuthor) {
            return authorManager.setNewAuthor(entAuthor);
        }

        public List<Entities.Author> AuthorsGetAll() {
            try { 
            return authorManager.AuthorsGetAll();
                }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}
