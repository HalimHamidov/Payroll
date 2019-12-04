using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Console.Model.TransactionParsers;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;
using Payroll.Core.Model.TransactionSources;

namespace Payroll.Console.Model.TransactionSources
{
    public class TextParserTransactionSource : BaseTransactionSource
    {
        public TextParserTransactionSource(IPayrollDatabase dbContext)
            : base(dbContext)
        {
            //
        }

        public override ITransaction GetTransaction()
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
                        transactionParser = new AddEmployeeTransactionParser(_dbContext);
                        break;
                    }
                case "ChgEmp":
                    {
                        transactionParser = new ChangeEmployeeTransactionParser(_dbContext);
                        break;
                    }
                case "DelEmp":
                    {
                        transactionParser = new DeleteEmployeeTransactionParser(_dbContext);
                        break;
                    }
                case "Payday":
                    {
                        transactionParser = new PaydayTransactionParser(_dbContext);
                        break;
                    }
                case "SalesReceipt":
                    {
                        transactionParser = new SalesReceiptTransactionParser(_dbContext);
                        break;
                    }
                case "ServiceCharge":
                    {
                        transactionParser = new ServiceChargeTransactionParser(_dbContext);
                        break;
                    }
                case "TimeCard":
                    {
                        transactionParser = new TimeCardTransactionParser(_dbContext);
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