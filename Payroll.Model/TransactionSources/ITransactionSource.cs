using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Transactions;

namespace Payroll.Core.Model.TransactionSources
{
    public interface ITransactionSource
    {
        ITransaction GetTransaction();
    }
}
