﻿using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class SalesReceiptTransactionParser : BaseTransactionTextParser
    {
        public SalesReceiptTransactionParser(IPayrollDatabase dbContext)
            : base(dbContext)
        {
            //
        }

        public override ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 4)
            {
                return null;
            }

            Int32 employeeID = Int32.Parse(words[1]);

            DateTime date = DateTime.Parse(words[2]);

            Double amount = Double.Parse(words[3]);

            ITransaction transaction = new SalesReceiptTransaction(employeeID, date, amount, _dbContext);

            return transaction;
        }
    }
}
