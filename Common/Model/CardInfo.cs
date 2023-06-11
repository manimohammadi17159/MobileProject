using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Model
{
    //! Models in Common project must be public
    //x internal class CardInfo
    public class CardInfo
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }

    }
}
