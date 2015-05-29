using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class GenderManager
    {
        private Data.GenderManager genderManager;
        public GenderManager() {
            this.genderManager = new Data.GenderManager();
        }

        public List<Entities.Gender> getAllGenders() {
            return this.genderManager.getAllGenders();
        }

        
    }
}
