using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class BiblioDbManager
    {
        protected BiblioOnlineDbEntities db;
        public BiblioDbManager() {
            this.db = new BiblioOnlineDbEntities();
        }
        public string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) 
               + s.Substring(1);
        }

    }
}
