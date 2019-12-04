﻿using System;
using Payroll.Console.Model.TransactionSources;
using Payroll.Core.Model.Transactions;
using Payroll.Core.Model.TransactionSources;

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
