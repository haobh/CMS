using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using System.Data.SqlClient;

namespace ModelEntity.DAO
{
    public class SharedDAO
    {
        /// <summary>
        /// Khoi tao Contructor
        /// </summary>
        DBContextCMS db = null;
        public SharedDAO()
        {
            db = new DBContextCMS();
        }
        //Dùng LINQ to Entity
        public List<Module> ListAll()
        {
            return db.Modules.ToList();
        }
    }
}
