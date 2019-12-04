using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Console.Model.TransactionParsers;
using Payroll.Core.Model.Transactions;
using Payroll.Core.Model.TransactionSources;

namespace Payroll.Console.Model.TransactionSources
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
                case "ChgEmp":
                    {
                        transactionParser = new ChangeEmployeeTransactionParser();
                        break;
                    }
                case "DelEmp":
                    {
                        transactionParser = new DeleteEmployeeTransactionParser();
                        break;
                    }
                case "Payday":
                    {
                        transactionParser = new PaydayTransactionParser();
                        break;
                    }
                case "SalesReceipt":
                    {
                        transactionParser = new SalesReceiptTransactionParser();
                        break;
                    }
                case "ServiceCharge":
                    {
                        transactionParser = new ServiceChargeTransactionParser();
                        break;
                    }
                case "TimeCard":
                    {
                        transactionParser = new TimeCardTransactionParser();
                        break;
                    }
            }

            if (transactionParser != null)
            {
                return transactionParser.Parse(transactionText);
            }

            return null;
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