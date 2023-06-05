using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Model
{
    internal class IdPattern
    {
        public string Year { get; set; }
        public string Mounth { get; set; }
        public string Day { get; set; }
        public string Second { get; set; }

        public string ConvertTwoDigit()
        {
            string? result = null;
            string zeroDigit = "0";
            var mounth = this.Mounth.ToString().ToCharArray();
            var day = this.Day.ToString().ToCharArray();
            var second = this.Second.ToString().ToCharArray();

            if (mounth.Length != 2) result = result + zeroDigit + mounth[0].ToString();
            else result = result + mounth[0].ToString() + mounth[1].ToString();

            if (day.Length != 2) result = result + zeroDigit + day[0].ToString();
            else result = result + day[0].ToString() + day[1].ToString();

            if (second.Length != 2) result = result + zeroDigit + second[0].ToString();
            else result = result + second[0].ToString() + second[1].ToString();
            
            return $"{this.Year}{result}";

        }

    }
}
