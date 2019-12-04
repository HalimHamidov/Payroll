using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public abstract class BaseTransactionTextParser : ITransactionTextParser
    {
        protected readonly IPayrollDatabase _dbContext;

        public BaseTransactionTextParser(IPayrollDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract ITransaction Parse(String text);
    }
}
