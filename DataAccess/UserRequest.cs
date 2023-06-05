using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using System.Data.SqlClient;

namespace MobileBank.DataAccess
{
    internal class UserRequest : IUserRequest
    {
        private IDbHelper _dbHelper;
        public UserRequest(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public User FindUser(string userName)
        {
            User result = null;
            string query = $"Select * From UserInfo Where Username= '{userName}'";
            SqlDataReader reader = null;

            reader = _dbHelper.ExecuteQuery(query);

            if (reader.Read())
            {
                result = new User()
                {
                    Id= reader.GetString(0),
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2),
                    Name = reader.GetString(3),
                    Lastname = reader.GetString(4),
                    MobileNumber = reader.GetString(5),
                };
            }
            reader.Close();

            return result;
        }
        public User FindUserWithId(string Id)
        {
            User result = null;
            string query = $"Select * From UserInfo Where Id= '{Id}'";
            SqlDataReader reader = null;

            reader = _dbHelper.ExecuteQuery(query);

            if (reader.Read())
            {
                result = new User()
                {
                    Id = reader.GetString(0),
                    UserName = reader.GetString(1),
                    Password = reader.GetString(2),
                    Name = reader.GetString(3),
                    Lastname = reader.GetString(4),
                    MobileNumber = reader.GetString(5),
                };
            }
            reader.Close();

            return result;
        }
        public void InsertNewUser(User newUser)
        {
            string query = $"Insert INTO UserInfo(Id,Username, Password, Name, Lastname, MobileNumber)" +
                           $" Values('{newUser.Id}','{newUser.UserName}','{newUser.Password}'," +
                           $"'{newUser.Name}','{newUser.Lastname}','{newUser.MobileNumber}')";

            _dbHelper.ExecuteNonQuery(query);

        }

    }
}
