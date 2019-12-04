using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class DeleteEmployeeTransactionParser : BaseTransactionTextParser
    {
        public DeleteEmployeeTransactionParser(IPayrollDatabase dbContext)
            : base(dbContext)
        {
            //
        }

        public override ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 2)
            {
                return null;
            }

            Int32 employeeID = Int32.Parse(words[1]);

            ITransaction transaction = new DeleteEmployeeTransaction(employeeID, _dbContext);

            return transaction;
        }
    }
}
