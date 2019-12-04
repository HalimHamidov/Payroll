using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class DeleteEmployeeTransactionParser : ITransactionTextParser
    {
        public ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 2)
            {
                return null;
            }

            Int32 employeeID = Int32.Parse(words[1]);

            ITransaction transaction = new DeleteEmployeeTransaction(employeeID);

            return transaction;
        }
    }
}
