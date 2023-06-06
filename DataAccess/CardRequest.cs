using MobileBank.Common;
using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using System.Data.SqlClient;

namespace MobileBank.DataAccess
{
    internal class CardRequest: ICardRequest
    {
        private IDbHelper _dbHelper;
        public CardRequest(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public CardInfo FindCard(string card)
        {
            string query = $"Select * From CardInfo Where CardNumber= '{card}'";

            CardInfo result = null;

            SqlDataReader reader = _dbHelper.ExecuteQuery(query);

            if (reader.Read())
            {
                result = new CardInfo()
                {
                    CardNumber = reader.GetString(1),
                    Balance = reader.GetDecimal(2),

                };
            }
            reader.Close();
            return result;

        }
        public CardInfo FindCardWithId(string Id)
        {
            string query = $"Select * From CardInfo Where Id= '{Id}'";

            CardInfo result = null;

            SqlDataReader reader = _dbHelper.ExecuteQuery(query);

            if (reader.Read())
            {
                result = new CardInfo()
                {
                    Id = reader.GetString(0),
                    CardNumber = reader.GetString(1),
                    Balance = reader.GetDecimal(2),

                };
            }
            reader.Close();
            return result;

        }
        public void UpdateBalance(string id, decimal newBalance)
        {
            string query = $"Update CardInfo Set Balance ='{newBalance}' Where Id='{id}'";

            _dbHelper.ExecuteNonQuery(query);

        }
        public void InsertNewCard(CardInfo newCard)
        {
            string query = $"Insert INTO CardInfo(Id,CardNumber, Balance)Values('{newCard.Id}','{newCard.CardNumber}','{newCard.Balance}')";
            

            _dbHelper.ExecuteNonQuery(query);

        }
    }
}
