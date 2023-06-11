//! remove unnecessary namespaces.
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// use file-scope namespace
namespace MobileBank.Common.Interface;

//! Common interfaces must be `public`
//x internal interface IBalanceUpdater
public interface IBalanceUpdater
{
    //! No need to add prefix `public` in interfaces. They are public by default.
    //x public decimal BalanceDeductor(string Id, decimal amount);
    //! Use naming conventions
    //x decimal BalanceDeductor(string Id, decimal amount);
    // Also the above method has spelling error. But no matter.
    decimal BalanceDeductor(string id, decimal amount);

    public decimal BalanceIncreaser(string Id, decimal amount);
}