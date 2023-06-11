using MobileBank.Common.Interface;
using System.Data;
using System.Data.SqlClient;
using MobileBank.Common;



namespace MobileBank.DataAccess
{
    internal class DbHelper : IDbHelper
    {
        // Make theme readonly.
        private readonly string _conString = "Server=.;Database=BankAccount;Trusted_Connection=True;";
        private readonly SqlConnection _con;
        public DbHelper()
        {
            _con = new SqlConnection(_conString);

            //! Not a good idea to leave the connection opened.
            //x _con.Open();

        }


        public int ExecuteNonQuery(string query)
        {
            // Create Command by Connection
            //x SqlCommand cmd = new SqlCommand(query, _con);
            var cmd = _con.CreateCommand();
            cmd.CommandText = query;

            //! Open connection and close it right after using it.
            //x return cmd.ExecuteNonQuery();
            try
            {
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                //! Command is no longer used. So it must be disposed.
                cmd.Dispose();
                _con.Close();
            }

        }

        public SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _con);
            //x return cmd.ExecuteReader();
            // Open Connection and let reader to close it
            _con.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //! No one will call Dispose method, if the owner class is not disposable.
        //! So let's make it disposable using IDisposable interface
        // Tip: In advanced programming there is a pattern, named Disposable Pattern. Refer to its documents.
        public void Dispose()
        {
            //if (_con != null && _con.State == ConnectionState.Open)_con.Close();
            //! Connection must be disposed.
            _con?.Close();
            _con?.Dispose();
        }
    }
}
