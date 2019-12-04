using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;

namespace Payroll.Core.Model.Transactions
{
    public abstract class BaseTransaction : ITransaction
    {
        protected readonly IPayrollDatabase _dbContext;

        public BaseTransaction(IPayrollDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract void Execute();
    }
}
