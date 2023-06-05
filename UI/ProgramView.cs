using System.Globalization;

namespace MobileBank.UI
{
    internal class ProgramView
    {
        public static int LoginOrSingUp()
        {
            Console.Clear();
            Console.WriteLine("1.Login\n2.Sing up\n\n");
            Console.Write("Enter number of option: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int ShowItems()
        {
            Console.Clear();
            int result;

            Console.Write("1.Account balance\n2.Buy mobile charge credit\n3.Money transfer\n4.Close the app\n\n");

            Console.Write("Select: ");
            result = Convert.ToInt16(Console.ReadLine());

            if (result > 4)
            {
                ShowItems();
            }

            return result;
        }
        public static void ShowAccountBalance(decimal balance)
        {
            Console.Clear();

            PersianCalendar PersianCalendar1 = new PersianCalendar();

            Console.WriteLine("{0}/{1}/{2}",
                PersianCalendar1.GetYear(DateTime.Now),
                PersianCalendar1.GetMonth(DateTime.Now),
                PersianCalendar1.GetDayOfMonth(DateTime.Now));


            Console.WriteLine(balance.ToString("N0", new NumberFormatInfo()
            {
                NumberGroupSizes = new[] { 3 },
                NumberGroupSeparator = "."
            }) + " Tomans");
            Console.ReadKey();

        }

    }
}
