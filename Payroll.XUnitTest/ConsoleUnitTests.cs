using System;
using Payroll.Console.Model.TransactionSources;
using Payroll.Core.Model.Transactions;
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

        [Fact]
        public void TestDeleteEmployee()
        {
            String transactionText = "DelEmp 4";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is DeleteEmployeeTransaction);
        }

        [Fact]
        public void TestSalesReceipt()
        {
            String transactionText = "SalesReceipt 5 2019.12.04 915,25";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is SalesReceiptTransaction);
        }

        [Fact]
        public void TestServiceCharge()
        {
            String transactionText = "ServiceCharge 6 2019.12.04 15,25";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ServiceChargeTransaction);
        }

        [Fact]
        public void TestTimeCard()
        {
            String transactionText = "TimeCard 7 2019.12.04 8,0";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is TimeCardTransaction);
        }

        [Fact]
        public void TestChangeEmployeeName()
        {
            String transactionText = "ChgEmp 8 Name Bob";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeNameTransaction);
        }

        [Fact]
        public void TestChangeEmployeeAddress()
        {
            String transactionText = "ChgEmp 9 Address Job";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeAddressTransaction);
        }

        [Fact]
        public void TestChangeEmployeeHourly()
        {
            String transactionText = "ChgEmp 10 Hourly 91,50";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeHourlyTransaction);
        }

        [Fact]
        public void TestChangeEmployeeSalaried()
        {
            String transactionText = "ChgEmp 11 Salaried 915,00";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeSalariedTransaction);
        }

        [Fact]
        public void TestChangeEmployeeCommissioned()
        {
            String transactionText = "ChgEmp 12 Commissioned 850,5 1,5";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeCommissionedTransaction);
        }

        [Fact]
        public void TestChangeEmployeeHold()
        {
            String transactionText = "ChgEmp 13 Hold";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeHoldTransaction);
        }

        [Fact]
        public void TestChangeEmployeeDirect()
        {
            String transactionText = "ChgEmp 14 Direct Bank2 123-456-789";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeDirectTransaction);
        }

        [Fact]
        public void TestChangeEmployeeMail()
        {
            String transactionText = "ChgEmp 15 Mail address@email.com";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeMailTransaction);
        }

        [Fact]
        public void TestChangeEmployeeMember()
        {
            String transactionText = "ChgEmp 15 Member 1 Dues 5,5";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeMemberTransaction);
        }

        [Fact]
        public void TestChangeEmployeeUnaffilated()
        {
            String transactionText = "ChgEmp 16 NoMember";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is ChangeUnaffilatedTransaction);
        }
        
        [Fact]
        public void TestPayday()
        {
            String transactionText = "Payday 2019.12.04";
            TextParserTransactionSource transactionSource = new TextParserTransactionSource();

            ITransaction transaction = transactionSource.GetTransaction(transactionText);
            Assert.True(transaction is PaydayTransaction);
        }
    }
}