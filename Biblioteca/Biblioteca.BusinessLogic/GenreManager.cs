using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class GenreManager
    {
        private Data.GenreManager genreManager;
        public GenreManager() {
            this.genreManager = new Data.GenreManager();
        }

        public List<Entities.Genre> getAllGenres() {
            return this.genreManager.getAllGenres();
        }
    }
}
