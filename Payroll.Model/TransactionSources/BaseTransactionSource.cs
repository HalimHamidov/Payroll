using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Core.Model.TransactionSources
{
    public abstract class BaseTransactionSource : ITransactionSource
    {
        protected readonly IPayrollDatabase _dbContext;

        public BaseTransactionSource(IPayrollDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract ITransaction GetTransaction();
    }
}
