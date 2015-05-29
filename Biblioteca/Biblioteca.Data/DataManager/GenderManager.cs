using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class GenderManager : BiblioDbManager
    {
        public GenderManager() : base() { }

        public List<Entities.Gender> getAllGenders()
        {
            List<Entities.Gender> entGenList = new List<Entities.Gender>();
            var genderList = this.db.Set<Genders>().ToList();
            foreach (var curGender in genderList) {
                entGenList.Add(DbToEntities(curGender));
            }
            return entGenList;
        }

        private Entities.Gender DbToEntities(Genders dbGender) {
            return new Entities.Gender(dbGender.id_gender, dbGender.description);
        }
    }
}
