using MobileBank.Common.Interface;

namespace MobileBank.Services
{
    internal class BalanceUpdater : IBalanceUpdater
    {
        private ICardRequest _cardRequest;
        public BalanceUpdater(ICardRequest dbRequest)
        {
            _cardRequest = dbRequest;
        }


        public decimal BalanceDeductor(string Id, decimal amount)
        {
            var account = _cardRequest.FindCardWithId(Id);

            if (account.Balance> amount)
            {
                account.Balance = account.Balance - amount;

                _cardRequest.UpdateBalance(account.Id, account.Balance);

                return account.Balance;
            }

            else
            {
                return 0;
            }

        }

        public decimal BalanceIncreaser(string Id, decimal amount)
        {
            var account = _cardRequest.FindCardWithId(Id);

            if (account.Balance > amount)
            {
                account.Balance = account.Balance + amount;

                _cardRequest.UpdateBalance(account.Id, account.Balance);

                return account.Balance;
            }

            else
            {
                return 0;
            }

        }
    }
}
