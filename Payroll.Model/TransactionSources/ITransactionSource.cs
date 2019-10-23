using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Transactions;

namespace Payroll.Model.TransactionSources
{
    public interface ITransactionSource
    {
        ITransaction GetTransaction();
    }
}
