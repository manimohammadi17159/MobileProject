namespace MobileBank.UI
{
    internal class TransfareView
    {

        public static string GetCardNumber()
        {
            Console.Clear();

            string result;

            Console.Write("Enter card number: ");
            result = Console.ReadLine();
            result.ToCharArray();

            if (result.Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The destination card number must have 16 digits");

                Thread.Sleep(2000);

                Console.ResetColor();
                GetCardNumber();
            }

            return result;
        }
        public static void IncorrectCardNumber()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Card number didnt found\nTry again");
            Thread.Sleep(2000);

            Console.ResetColor();
        }
        public static void ShowInfo(string name, string lastname, string card)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Clear();
            Console.Write($"{name} {lastname}\n{card}\n");

            Console.ResetColor();

            Console.ReadKey();

        }
        public static decimal CheckTransfare(decimal balance)// Check tha balance that amount was not biger
        {
            bool needAsk = true;
            decimal result = 0;

            while (needAsk == true)
            {
                Console.Clear();

                Console.Write("Enter ammount of transfare: ");
                result = Convert.ToDecimal(Console.ReadLine());

                if (result < balance)
                {
                    return result;
                    needAsk = false;
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Inventory is low");
                    Thread.Sleep(2000);

                    Console.ResetColor();
                }


            }


            return result;

        }

        public static void TransfareSuccessful()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Transfare successful");

            Console.ResetColor();

            Console.ReadKey();

        }

    }


}



