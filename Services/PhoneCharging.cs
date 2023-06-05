using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.UI;

namespace MobileBank.Services
{
    internal class PhoneCharging : IPhoneCharging
    {
        private IUserRequest _userRequest;
        private IBalanceUpdater _balanceUpdater;
        private string _userId;
        public PhoneCharging(IBalanceUpdater balanceUpdater, IUserRequest userRequest, string userId)
        {
            _balanceUpdater = balanceUpdater;
            _userRequest = userRequest;
            _userId = userId;
        }

        public decimal BuyMobileCharge()
        {
            User account = null;

            account = _userRequest.FindUserWithId(_userId);

            decimal ammount = PhoneChargingView.SelectItem();
            decimal newBalance;

            PhoneChargingView.GetPhoneNumber(account.MobileNumber, ammount);

            newBalance = _balanceUpdater.BalanceDeductor(_userId, ammount);///

            return newBalance;
        }
    }
}
