using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class AuthorManager : BiblioDbManager
    {
        public AuthorManager() : base() { }

        public List<Entities.Author> AuthorsGetAll() {
            try
            {
                var author = (from auxTable in this.db.Authors select auxTable).ToList();
                List<Entities.Author> authorList = new List<Entities.Author>();
                foreach (var curAuthor in author)
                {
                    authorList.Add(DbToEntities(curAuthor));
                }
                return authorList;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public bool setNewAuthor(Entities.Author entAuthor) {
            try {
                Authors dbAuthor = new Authors();
                dbAuthor.first_name = entAuthor.first_name.ToLower();
                dbAuthor.last_name = entAuthor.last_name.ToLower();
                this.db.Authors.Add(dbAuthor);
                this.db.SaveChanges();
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            return true;
        }

        public Entities.Author DbToEntities(Authors dbAuthor)
        {
            return new Entities.Author(dbAuthor.id_author, UppercaseFirst(dbAuthor.first_name), UppercaseFirst(dbAuthor.last_name));
        }

    }
}
