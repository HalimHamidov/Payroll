using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Transactions;

namespace Payroll.Console.TransactionParsers
{
    public interface ITransactionTextParser
    {
        ITransaction Parse(String text);
    }
}
