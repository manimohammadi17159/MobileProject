using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBank.Common.Interface
{
    internal interface IBalanceUpdater
    {
        public decimal BalanceDeductor(string Id, decimal amount);

        public decimal BalanceIncreaser(string Id, decimal amount);

    }
}
