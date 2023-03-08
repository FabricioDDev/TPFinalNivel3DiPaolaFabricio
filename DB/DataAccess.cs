using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB
{
    public class DataAccess
    {
        //Builder
        public DataAccess() { connection = new SqlConnection("server=DESKTOP-J1JBL3C\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true"); command = new SqlCommand(); }
        //Attributes
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        //Properties
        public SqlDataReader readerProp
        {
            get { return reader; }
        }
    }
}
