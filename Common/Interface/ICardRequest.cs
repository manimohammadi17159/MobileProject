using MobileBank.Common.Model;
using MobileBank.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Interface
{
    internal interface ICardRequest
    {
        public CardInfo FindCard(string cardNumber);
        public CardInfo FindCardWithId(string Id);
        public void InsertNewCard(CardInfo cardInfo);
        public void UpdateBalance(string id, decimal newBalance);

    }
}
