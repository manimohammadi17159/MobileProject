namespace MobileBank.Common.Model;

internal class CardNumberPattern
{
    //? Why static ?
    public static string First { get; set; } = "5022";
    public static string Second { get; set; } = "2910";
    public string? Fourth { get; set; }
    public string? Third { get; set; }

    //! [Advanced] Functional Principle: Have no side-effect. Here `result` is side-effect.
    //public override string ToString()
    //{
    //    var result = $"{First}{Second}{this.Third}{this.Fourth}";
    //    return result;
    //}

    // Rewriting code:
    //public override string ToString()
    //{
    //    return $"{First}{Second}{this.Third}{this.Fourth}";
    //}

    //! It would be good to convert the method to expression method:
    // Rewriting code:
    //public override string ToString() 
    //    => $"{First}{Second}{this.Third}{this.Fourth}";
}