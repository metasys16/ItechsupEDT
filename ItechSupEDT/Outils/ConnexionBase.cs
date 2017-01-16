using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ItechSupEDT.Outils
{
    class ConnexionBase
    {
        private static ConnexionBase instance;
        private SqlConnection conn;

        public SqlConnection Conn
        {
            get { return conn; }
           private set { conn = value; }
        }

        public static ConnexionBase GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnexionBase();
            }

            return instance;
        }

        private ConnexionBase()
        {
            this.Conn = new SqlConnection();
            this.Conn.ConnectionString = "Data Source=DESKTOP-EUF41LS;Initial Catalog=EDT_db;Integrated Security=True";
            this.Conn.Open();
        }
    }
}
