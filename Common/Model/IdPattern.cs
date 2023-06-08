using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Model
{
    internal class IdPattern
    {
        //! CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
        public string? Year { get; set; }
        public string Mounth { get; set; }
        public string Day { get; set; }
        public string Second { get; set; }

        //! This code can be optimized and simplified.
        //public string ConvertTwoDigit()
        //{
        //    string? result = null;
        //    string zeroDigit = "0";
        //    var mounth = this.Mounth.ToString().ToCharArray();
        //    var day = this.Day.ToString().ToCharArray();
        //    var second = this.Second.ToString().ToCharArray();

        //    if (mounth.Length != 2) result = result + zeroDigit + mounth[0].ToString();
        //    else result = result + mounth[0].ToString() + mounth[1].ToString();

        //    if (day.Length != 2) result = result + zeroDigit + day[0].ToString();
        //    else result = result + day[0].ToString() + day[1].ToString();

        //    if (second.Length != 2) result = result + zeroDigit + second[0].ToString();
        //    else result = result + second[0].ToString() + second[1].ToString();

        //    return $"{this.Year}{result}";

        //}

        // Rewriting code:
        //public string ConvertTwoDigit()
        //{
        //    var month = this.Mounth.PadLeft(2, '0');
        //    var day = this.Day.PadLeft(2, '0');
        //    var second = this.Second.PadLeft(2, '0');

        //    var result = $"{month}{day}{second}";

        //    return $"{this.Year}{result}";
        //}

        //! Exceptions are not handled.
        // Rewriting code:
        //public string ConvertTwoDigit()
        //{
        //    if (this.Mounth == null || this.Day == null || this.Second == null)
        //    {
        //        throw new ArgumentNullException("مقادیر نباید null باشند.");
        //    }

        //    if (!int.TryParse(this.Mounth.ToString(), out _) ||
        //        !int.TryParse(this.Day.ToString(), out _) ||
        //        !int.TryParse(this.Second.ToString(), out _))
        //    {
        //        throw new ArgumentException("مقادیر باید عددی باشند.");
        //    }

        //    var month = this.Mounth.PadLeft(2, '0');
        //    var day = this.Day.PadLeft(2, '0');
        //    var second = this.Second.PadLeft(2, '0');

        //    var result = $"{month}{day}{second}";

        //    return $"{this.Year}{result}";
        //}

        //! Now, it's much easier to use integer variables, instead of strings.
        public string ConvertTwoDigit()
        {
            if (this.Mounth == null || this.Day == null || this.Second == null)
            {
                throw new ArgumentNullException("مقادیر نباید null باشند.");
            }

            if (!int.TryParse(this.Mounth, out int monthValue) ||
                !int.TryParse(this.Day, out int dayValue) ||
                !int.TryParse(this.Second, out int secondValue))
            {
                throw new ArgumentException("مقادیر باید عددی باشند.");
            }

            var month = monthValue.ToString("00");
            var day = dayValue.ToString("00");
            var second = secondValue.ToString("00");

            var result = $"{month}{day}{second}";

            return $"{this.Year}{result}";
        }
    }
}
