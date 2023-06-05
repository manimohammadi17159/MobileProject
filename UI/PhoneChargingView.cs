namespace MobileBank.UI
{
    internal class PhoneChargingView
    {

        public static decimal SelectItem()
        {
        
            int[] CreditItem = new int[5] {1000, 2000, 3000, 5000, 10000 };
            int index = 5;
            decimal result;

            while (index > 4)
            {
                Console.Clear();
                for (int i = 0; i < CreditItem.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{CreditItem[i]} tomans mobile charge");

                }
                Console.Write("Select: ");
                index = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            result = CreditItem[index] + CreditItem[index] * 9 / 100;

            return result;

        }
        public static void GetPhoneNumber(string mobile, decimal ammount)
        {
            bool needAsk = true;


            while (needAsk == true)
            {
                Console.Clear();

                Console.Write($"{mobile}\nDo you want to buy charge for this number? |YES or NO|: ");

                string userRequest = Console.ReadLine();

                if (userRequest.ToLower() == "yes")
                {

                    Console.WriteLine($"{mobile} Charged {ammount} Tomans");
                    needAsk = false;
                    Console.ReadKey();
                }

                else if (userRequest.ToLower() == "no")
                {

                    Console.Write("Enter your mobile number:");
                    string number = Console.ReadLine();

                    Console.WriteLine($"{number} charged {ammount} Tomans");
                    needAsk = false;

                    Console.ReadKey();
                }
            }


        }

    }
}
