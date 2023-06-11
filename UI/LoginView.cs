namespace MobileBank.UI
{
    internal class LoginView
    {
        public static (string user, string pass) Asking()
        {
            Console.Clear();
            (string user, string pass) info;

            Console.Write("Enter username: ");
            info.user = Console.ReadLine();

            //! Password must be hidden.
            Console.Write("Enter password: ");
            info.pass = Console.ReadLine();

            //? Why?
            Thread.Sleep(TimeSpan.FromSeconds(3));

            return info;


        }
        public static void DidntFound()
        {
            
            Console.ForegroundColor= ConsoleColor.Red;

            Console.WriteLine("User or password is incorrect\nTry again... ");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.ResetColor();
            Console.Clear();

        }


    }
}
