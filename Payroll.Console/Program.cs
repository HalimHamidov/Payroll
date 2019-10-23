using System;
using Payroll.Console.TransactionSources;
using Payroll.Model.Transactions;
using Payroll.Model.TransactionSources;

namespace Payroll.Console
{
    class Program
    {
        static void Main(String[] args)
        {
            ITransactionSource transactionSource = new TextParserTransactionSource();

            while (true)
            {
                ITransaction transaction = transactionSource.GetTransaction();

                if (transaction != null)
                {
                    transaction.Execute();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
