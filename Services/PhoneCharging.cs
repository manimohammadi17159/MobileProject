using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.DataAccess;
using MobileBank.UI;

namespace MobileBank.Services
{
    internal class PhoneCharging : IPhoneCharging
    {
        private IUserRequest _userRequest;
        private IBalanceUpdater _balanceUpdater;
        private string _userId;
        private ICardRequest _cardRequest;
        public PhoneCharging(IBalanceUpdater balanceUpdater,ICardRequest cardRequest ,IUserRequest userRequest, string userId)
        {
            _balanceUpdater = balanceUpdater;
            _userRequest = userRequest;
            _cardRequest = cardRequest;
            _userId = userId;
        }

        public decimal BuyMobileCharge()
        {
            User user = null;
            CardInfo card = null;
            

            user = _userRequest.FindUserWithId(_userId);
            card = _cardRequest.FindCardWithId(_userId);

            decimal ammount = PhoneChargingView.SelectItem();

            bool check = PhoneChargingView.CheckBalance(card.Balance, ammount);

            if (check == true)
            {
                decimal newBalance;

                PhoneChargingView.GetPhoneNumber(user.MobileNumber, ammount);

                newBalance = _balanceUpdater.BalanceDeductor(_userId, ammount);

                return newBalance;
            }
            else
            {
                return card.Balance;
            }
           
        }



    }
}
