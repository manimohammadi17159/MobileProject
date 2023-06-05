using MobileBank.Common.Interface;
using MobileBank.Common.Model;
using System.Data.SqlTypes;

namespace MobileBank.UI
{
    internal class SignUpView
    {

        public static void ShowCardInfo(CardInfo cardInfo)
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.Write($"Your card information: \nCard number: {cardInfo.CardNumber}\nCard balance: {cardInfo.Balance}");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static User GetUserInfo()
        {
            User result = new User();

            Console.Clear();
            Console.Write("Enter your name: ");
            result.Name = Console.ReadLine();

            Console.Write("Enter your lastname: ");
            result.Lastname = Console.ReadLine();

            Console.Write("Enter your mobilenumber: ");
            result.MobileNumber = Console.ReadLine();

            if (result.Name == null || result.Lastname == null || result.MobileNumber == null)
            {
                GetUserInfo();
            }
            return result;

        }
        public static (string user, string pass) CreadteUserName()
        {
            (string u, string p) result;
            Console.Clear();

            Console.Write("Enter your username: ");
            result.u = Console.ReadLine();

            Console.Write("Enter your password: ");
            result.p = Console.ReadLine();

            if (result.u == null || result.p == null)
            {
                CreadteUserName();
            }

            return result;

        }

        public static void SingUpError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("This username is already registered");
            Console.ReadKey();
            Console.ResetColor();
        }
        public static void SignUpSuccessful() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sign up was successful");
            Console.ReadKey();
            Console.ResetColor();

        }
    }
}
