using MobileBank.Common.Interface;
using System.Data;
using System.Data.SqlClient;
using MobileBank.Common;



namespace MobileBank.DataAccess
{
    internal class DbHelper : IDbHelper
    {
        private string _conString = "Server=.;Database=BankAccount;Trusted_Connection=True;";
        private SqlConnection _con;
        public DbHelper()
        {
            _con = new SqlConnection(_conString);
            _con.Open();

        }


        public int ExecuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _con);
            return cmd.ExecuteNonQuery();
         
        }

        public SqlDataReader ExecuteQuery(string query)
        {
          
            SqlCommand cmd = new SqlCommand(query, _con);
            return cmd.ExecuteReader();
      

        }

        public void Dispose()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }
    }
}
