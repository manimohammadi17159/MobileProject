using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.UI;


namespace MobileBank.Services
{
    internal class MoneyTransfare : IMoneyTransfare
    {
        private ICardRequest _cardRequest;
        private IBalanceUpdater _balanceUpdater;
        private IUserRequest _userRequest;
        private string _userId;
        private decimal _newBalance;
        public MoneyTransfare(ICardRequest cardRequest, IUserRequest userRequest, IBalanceUpdater balanceUpdater, string userId)
        {
            _cardRequest = cardRequest;
            _balanceUpdater = balanceUpdater;
            _userRequest = userRequest;
            //? Inverted.
            //x userId = _userId;
            _userId = userId;
        }

        public decimal StartTranfare()
        {
            CardInfo card1 = _cardRequest.FindCardWithId(_userId);
            //! Initialization is not required.
            //x CardInfo card2 = new();
            CardInfo card2;
            User user2Info = new();
            _cardRequest.FindCardWithId(_userId);

            card2 = Destinationcard();

            user2Info = _userRequest.FindUserWithId(card2.Id);

            TransfareView.ShowInfo(user2Info.Name, user2Info.Lastname, card2.CardNumber);

            decimal ammount = TransfareView.CheckTransfare(card1.Balance);

            Transfare(_userId, user2Info.Id, ammount);

            //? Why should `_newBalance` be kept? It can be removed.
            _newBalance = card1.Balance - ammount;

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
            //! Id1 is always _userId. So it can be removed. 
            _balanceUpdater.BalanceDeductor(Id1, amount);
            _balanceUpdater.BalanceIncreaser(Id2, amount);
        }

        //! Never used method. Can be removed.
        //private decimal CheckTransfare(decimal balance)
        //{
        //    decimal result;
        //    result = TransfareView.CheckTransfare(balance);

        //    return result;
        //}
    }
}
