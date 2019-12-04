using System;
using Payroll.Console.Model.TransactionSources;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;
using Payroll.Core.Model.TransactionSources;

namespace Payroll.Console
{
    class Program
    {
        private static readonly IPayrollDatabase _dbContext;

        static Program()
        {
            _dbContext = new InMemoryPayrollDatabase();
        }

        static void Main(String[] args)
        {
            ITransactionSource transactionSource = new TextParserTransactionSource(_dbContext);

            while (true)
            {
                ITransaction transaction = transactionSource.GetTransaction();

                if (transaction != null)
                {
                    try
                    {
                        transaction.Execute();
                    }
                    catch (InvalidOperationException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
