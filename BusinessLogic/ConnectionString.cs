using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BusinessLogic
{
    public class ConnectionString
    {
        public static NpgsqlConnection Connection()
        {
            string cstring = "Write your Connection String Here";//"Server=;Port=;Database=;User Id=;Password="
            NpgsqlConnection con = new NpgsqlConnection(cstring);
            return con;
        }
    }
}
