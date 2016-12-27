using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using System.Data.SqlClient;

namespace ModelEntity.DAO
{
    class ModuleDAO
    {

        /// <summary>
        /// Khoi tao Contructor
        /// </summary>
        DBContextCMS db = null;
        public ModuleDAO()
        {
            db = new DBContextCMS();
        }
    }
}
