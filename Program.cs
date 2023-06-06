using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using MobileBank.DataAccess;
using MobileBank.Services;
using MobileBank.UI;

namespace MobileBank
{
    internal class Program
    {

        static void Main(string[] args)
        {


            User userInfo = null;
            CardInfo cardInfo = null;

            bool needAsking = true;

            IDbHelper dbHelper = new DbHelper();

            IUserRequest userRequest = new UserRequest(dbHelper);

            ICardRequest cardRequest = new CardRequest(dbHelper);

            ISignUp signUp = new SignUp(userRequest, cardRequest);

            Ilogin login = new Login(userRequest, cardRequest);

            IBalanceUpdater balanceUpdater = new BalanceUpdater(cardRequest);

            IPhoneCharging PhoneChargin = null;

            IMoneyTransfare moneyTransfare = null;

            int option;

            do
            {
                option = ProgramView.LoginOrSingUp();

                switch (option)
                {
                    case 1:
                        userInfo = login.FindeUser();
                        cardInfo = login.FindCard(userInfo.Id);

                        PhoneChargin = new PhoneCharging(balanceUpdater, cardRequest, userRequest, userInfo.Id);

                        moneyTransfare = new MoneyTransfare(cardRequest, userRequest, balanceUpdater, userInfo.Id);
                        break;

                    case 2:
                        signUp.StartSignUp();
                        break;

                    default:
                        break;
                }  
            } while (option != 1);
            



            while (needAsking == true)
            {
                switch (ProgramView.ShowItems())
                {
                    case 1:
                        ProgramView.ShowAccountBalance(cardInfo.Balance);
                        break;

                    case 2:
                        cardInfo.Balance = PhoneChargin.BuyMobileCharge();
                        break;

                    case 3:
                        cardInfo.Balance = moneyTransfare.StartTranfare();
                        break;

                    case 4:
                        needAsking = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}