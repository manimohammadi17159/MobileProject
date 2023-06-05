using MobileBank.Common;
using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.DataAccess;
using MobileBank.UI;


namespace MobileBank.Services
{
    internal class MoneyTransfare : IMoneyTransfare
    {
        private ICardRequest _cardRequest;
        private IBalanceUpdater _balanceUpdater;
        private IUserRequest _userRequest;
        private User _user;
        private CardInfo _card;
        private decimal _newBalance;
        public MoneyTransfare(ICardRequest cardRequest,IUserRequest userRequest ,IBalanceUpdater balanceUpdater, User user)
        {
            _cardRequest = cardRequest;
            _balanceUpdater = balanceUpdater;
            _userRequest = userRequest;
            _user = user;

        }

        public decimal StartTranfare()
        {
            CardInfo cardInfo = new();
            User userInfo = new();
            
            cardInfo = Destinationcard();

            userInfo = _userRequest.FindUserWithId(cardInfo.Id);

            TransfareView.ShowInfo(userInfo.Name, userInfo.Lastname, cardInfo.CardNumber);

            decimal ammount = TransfareView.CheckTransfare(_card.Balance);

            Transfare(_user.Id, userInfo.Id, ammount);

            _newBalance = _card.Balance - ammount;

            TransfareView.TransfareSuccessful();

            return _newBalance;
        }


        private CardInfo Destinationcard()//get card number and validation
        {
            bool needAsk = true;
            CardInfo result = null;

            while (needAsk == true)
            {
                string card = TransfareView.GetCardNumber();

                result = _cardRequest.FindCard(card);//validation

                if (result == null)
                {
                    TransfareView.IncorrectCardNumber();

                }

                else
                {
                    needAsk = false;

                }

            }

            return result;

        }

        private void Transfare(string Id1, string Id2, decimal amount)// user1 is origin card and user2 is destination card
        {
            _balanceUpdater.BalanceDeductor(Id1, amount);
            _balanceUpdater.BalanceIncreaser(Id2, amount);
        }

        private decimal CheckTransfare(decimal balance) 
        {
            decimal result;
            result = TransfareView.CheckTransfare(balance);     
            
            return result;
        }
    }
}
