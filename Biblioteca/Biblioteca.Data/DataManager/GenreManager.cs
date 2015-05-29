using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class GenreManager : BiblioDbManager
    {
        public GenreManager() : base() { }

        public List<Entities.Genre> getAllGenres() {
            var genreList = this.db.Set<Genres>().ToList();
            List<Entities.Genre> entGenList = new List<Entities.Genre>();
            foreach (var curGenre in genreList) {
                entGenList.Add(DbToEntities(curGenre));
            }
            return entGenList;

        }

        private Entities.Genre DbToEntities(Genres dbGenre) {
            return new Entities.Genre(dbGenre.id_genre, dbGenre.description);
        }
    }
}
