using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class PaydayTransactionParser : BaseTransactionTextParser
    {
        public PaydayTransactionParser(IPayrollDatabase dbContext)
            : base(dbContext)
        {

        }

        public override ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 2)
            {
                return null;
            }

            DateTime date = DateTime.Parse(words[1]);

            ITransaction transaction = new PaydayTransaction(date, _dbContext);

            return transaction;
        }
    }
}
