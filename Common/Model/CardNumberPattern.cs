namespace MobileBank.Common.Model
{
    internal class CardNumberPattern
    {
        public static string First { get; set; } = "5022";
        public static string Second { get; set; } = "2910";
        public string Third { get; set; }
        public string Fourth { get; set; }

        public override string ToString()
        {
            string result = $"{First}{Second}{this.Third}{this.Fourth}";
            return result;
        }

    }
}
