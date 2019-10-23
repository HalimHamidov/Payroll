using System;
using Payroll.Console.TransactionSources;
using Payroll.Model.Transactions;
using Xunit;

namespace Payroll.XUnitTest
{
    public class ConsoleUnitTests
    {
        [Fact]
        public void TestAddSalariedEmployee()
        {
            String transactionText = "AddEmp 1 Bill Home S 915,25";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is AddSalariedTransaction);
        }

        [Fact]
        public void TestAddHourlyEmployee()
        {
            String transactionText = "AddEmp 2 Bob Home H 91,15";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is AddHourlyTransaction);
        }

        [Fact]
        public void TestAddCommissionedEmployee()
        {
            String transactionText = "AddEmp 3 Michael Home C 800,5 2,5";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is AddCommissionedTransaction);
        }
    }
}