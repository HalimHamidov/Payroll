using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class PaydayTransactionParser : ITransactionTextParser
    {
        public ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 2)
            {
                return null;
            }

            DateTime date = DateTime.Parse(words[1]);

            ITransaction transaction = new PaydayTransaction(date);

            return transaction;
        }
    }
}
