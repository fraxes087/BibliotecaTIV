using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class RentManager
    {
        private Data.RentManager rentManager;
        public RentManager() {
            this.rentManager = new Data.RentManager();
        }

        public List<Entities.Rent> getAllRents() {
            return this.rentManager.getAllRents();
        }

        public bool reserveBook(Entities.Rent entRent) {
            return this.rentManager.reserveBook(entRent);
        }
    }
}
