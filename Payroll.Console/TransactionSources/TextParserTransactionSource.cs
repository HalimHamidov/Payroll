using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Console.TransactionParsers;
using Payroll.Model.Transactions;
using Payroll.Model.TransactionSources;

namespace Payroll.Console.TransactionSources
{
    public class TextParserTransactionSource : ITransactionSource
    {
        public ITransaction GetTransaction()
        {
            System.Console.Write("> ");
            String transactionText = System.Console.ReadLine();

            return GetTransaction(transactionText);
        }

        public ITransaction GetTransaction(String transactionText)
        {
            ITransactionTextParser transactionParser = null;

            switch (GetTransactionName(transactionText))
            {
                case "AddEmp":
                    {
                        transactionParser = new AddEmployeeTransactionParser();
                        break;
                    }
            }

            return transactionParser.Parse(transactionText);
        }

        private String GetTransactionName(String transactionText)
        {
            if (String.IsNullOrEmpty(transactionText))
            {
                return null;
            }

            String[] words = transactionText.Split(' ');

            if (words.Length == 0)
            {
                return null;
            }

            return words[0];
        }
    }
}