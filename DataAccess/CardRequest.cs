using MobileBank.Common;
using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using System.Data.SqlClient;

namespace MobileBank.DataAccess
{
    internal class CardRequest: ICardRequest
    {
        //! IDE0044 Make field readonly
        //x private IDbHelper _dbHelper;
        private readonly IDbHelper _dbHelper;

        public CardRequest(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        //! SQL-Injection is not considered.
        //public CardInfo FindCard(string card)
        //{
        //    string query = $"Select * From CardInfo Where CardNumber= '{card}'";

        //    CardInfo result = null;

        //    SqlDataReader reader = _dbHelper.ExecuteQuery(query);

        //    if (reader.Read())
        //    {
        //        result = new CardInfo()
        //        {
        //            CardNumber = reader.GetString(1),
        //            Balance = reader.GetDecimal(2),

        //        };
        //    }
        //    reader.Close();
        //    return result;

        //}

        //! Applying SQL Injection
        // Rewriting code
        //public CardInfo FindCard(string card)
        //{
        //    string query = $"Select * From CardInfo Where CardNumber= '{card}' OR 1=1; --'";

        //    CardInfo result = null;

        //    SqlDataReader reader = _dbHelper.ExecuteQuery(query);

        //    if (reader.Read())
        //    {
        //        result = new CardInfo()
        //        {
        //            CardNumber = reader.GetString(1),
        //            Balance = reader.GetDecimal(2),

        //        };
        //    }
        //    reader.Close();
        //    return result;
        //}

        //! Optimizing code
        // Tip: The return value must be nullable
        public CardInfo FindCard(string card)
        {
            //! `card` must be checked to be not null. (Important)
            // The `using` statement ensures that the `DataReader` is closed and disposed when it is no longer needed.
            using var reader = _dbHelper.ExecuteQuery($"Select * From CardInfo Where CardNumber= '{card}' OR 1=1; --'");

            //! nullability is not handled.
            // CS8603 - Possible null reference return.
            return reader.Read()
                ? new CardInfo()
                {
                    CardNumber = reader.GetString(1),
                    Balance = reader.GetDecimal(2),

                }
                : null;
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

        //! It would be goo to verify whether the `Update` command has successfully updated any record by checking its return value.
        public void UpdateBalance(string id, decimal newBalance)
        {
            string query = $"Update CardInfo Set Balance ='{newBalance}' Where Id='{id}'";

            _dbHelper.ExecuteNonQuery(query);

        }
        
        //! Validation checks are not considered.
        public void InsertNewCard(CardInfo newCard)
        {
            string query = $"Insert INTO CardInfo(Id,CardNumber, Balance)Values('{newCard.Id}','{newCard.CardNumber}','{newCard.Balance}')";
            

            _dbHelper.ExecuteNonQuery(query);

        }
    }
}
