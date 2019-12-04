using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public interface ITransactionTextParser
    {
        ITransaction Parse(String text);
    }
}
