using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Interface
{
    internal interface IDbHelper
    {
        public int ExecuteNonQuery(string query);

        public SqlDataReader ExecuteQuery(string query);

    }
}
