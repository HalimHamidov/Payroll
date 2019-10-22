using System;
using Payroll.Model.Affilations;
using Payroll.Model.Classifications;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;
using Payroll.Model.Methods;
using Payroll.Model.Schedules;
using Payroll.Model.Transactions;
using Xunit;

namespace Payroll.XUnitTest
{
    public class UnitTest
    {
        [Fact]
        public void TestAddSalariedEmployee()
        {
            Int32 employeeID = 1;
            AddSalariedTransaction transaction = new AddSalariedTransaction(employeeID, "Bob", "Home", 1000.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Bob", employee.Name);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is SalariedPaymentClassification);
            SalariedPaymentClassification salariedClassification = paymentClassification as SalariedPaymentClassification;
            Assert.Equal(1000.0, salariedClassification.Salary, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is MonthlyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestAddHourlyEmployee()
        {
            Int32 employeeID = 2;
            AddHourlyTransaction transaction = new AddHourlyTransaction(employeeID, "Michael", "Home", 100.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Michael", employee.Name);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is HourlyPaymentClassification);
            HourlyPaymentClassification hourlyClassification = paymentClassification as HourlyPaymentClassification;
            Assert.Equal(100.0, hourlyClassification.HourlyRate, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is WeeklyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestAddCommissionedEmployee()
        {
            Int32 employeeID = 3;
            AddCommissionedTransaction transaction = new AddCommissionedTransaction(employeeID, "Jacob", "Home", 1000.0, 10.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Jacob", employee.Name);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is CommissionedPaymentClassification);
            CommissionedPaymentClassification commissionedClassification = paymentClassification as CommissionedPaymentClassification;
            Assert.Equal(1000.0, commissionedClassification.Salary, 3);
            Assert.Equal(10.0, commissionedClassification.CommissionRate, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is BiweeklyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestDeleteEmployee()
        {
            Int32 employeeID = 4;
            AddCommissionedTransaction transaction1 = new AddCommissionedTransaction(employeeID, "William", "Home", 2500.0, 3.2);
            transaction1.Execute();

            Employee employee1 = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee1);

            DeleteEmployeeTransaction transaction2 = new DeleteEmployeeTransaction(employeeID);
            transaction2.Execute();

            Employee employee2 = PayrollDatabase.GetEmployee(employeeID);
            Assert.Null(employee2);
        }

        [Fact]
        public void TestAddTimeCard()
        {
            Int32 employeeID = 5;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Bill", "Home", 15.25);
            transaction1.Execute();

            TimeCardTransaction transaction2 = new TimeCardTransaction(employeeID, new DateTime(2019, 1, 1), 8.0);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is HourlyPaymentClassification);
            HourlyPaymentClassification hourlyClassification = paymentClassification as HourlyPaymentClassification;

            TimeCard timeCard = hourlyClassification.GetTimeCard(new DateTime(2019, 1, 1));
            Assert.NotNull(timeCard);
            Assert.Equal(8.0, timeCard.Hours, 3);
        }

        [Fact]
        public void TestAddSalesReceipt()
        {
            Int32 employeeID = 6;
            AddCommissionedTransaction transaction1 = new AddCommissionedTransaction(employeeID, "James", "Home", 1000.0, 3.2);
            transaction1.Execute();

            SalesReceiptTransaction transaction2 = new SalesReceiptTransaction(employeeID, new DateTime(2019, 1, 1), 100.0);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is CommissionedPaymentClassification);
            CommissionedPaymentClassification commissionedClassification = paymentClassification as CommissionedPaymentClassification;

            SalesReceipt salesReceipt = commissionedClassification.GetSalesReceipt(new DateTime(2019, 1, 1));
            Assert.NotNull(salesReceipt);
            Assert.Equal(100.0, salesReceipt.Amount, 3);
        }

        [Fact]
        public void TestAddServiceCharge()
        {
            Int32 employeeID = 7;
            AddSalariedTransaction transaction1 = new AddSalariedTransaction(employeeID, "Daniel", "Home", 1000.0);
            transaction1.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);
            Assert.True(employee.Affilation is NoAffilation);

            UnionAffilation affilation = new UnionAffilation();
            employee.Affilation = affilation;

            Int32 memberID = 86;
            PayrollDatabase.AddUnionMember(memberID, employee);

            ServiceChargeTransaction transaction2 = new ServiceChargeTransaction(memberID, new DateTime(2019, 1, 1), 12.95);
            transaction2.Execute();

            ServiceCharge serviceCharge = affilation.GetServiceCharge(new DateTime(2019, 1, 1));
            Assert.NotNull(serviceCharge);
            Assert.Equal(12.95, serviceCharge.Amount, 3);
        }

        [Fact]
        public void TestChangeNameTransaction()
        {
            Int32 employeeID = 8;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Benjamin", "Home", 15.25);
            transaction1.Execute();

            ChangeNameTransaction transaction2 = new ChangeNameTransaction(employeeID, "Bob");
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);
            Assert.Equal("Bob", employee.Name);
        }

        [Fact]
        public void TestChangeAddressTransaction()
        {
            Int32 employeeID = 9;
            AddSalariedTransaction transaction1 = new AddSalariedTransaction(employeeID, "Logan", "Home", 915.25);
            transaction1.Execute();

            ChangeAddressTransaction transaction2 = new ChangeAddressTransaction(employeeID, "Office");
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);
            Assert.Equal("Office", employee.Address);
        }

        [Fact]
        public void TestChangeHourlyTransaction()
        {
            Int32 employeeID = 10;
            AddCommissionedTransaction transaction1 = new AddCommissionedTransaction(employeeID, "Matthew", "Home", 1000.0, 3.2);
            transaction1.Execute();

            ChangeHourlyTransaction transaction2 = new ChangeHourlyTransaction(employeeID, 27.52);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is HourlyPaymentClassification);
            HourlyPaymentClassification hourlyClassification = paymentClassification as HourlyPaymentClassification;
            Assert.Equal(27.52, hourlyClassification.HourlyRate, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is WeeklyPaymentSchedule);
        }

        [Fact]
        public void TestChangeSalariedTransaction()
        {
            Int32 employeeID = 11;
            AddCommissionedTransaction transaction1 = new AddCommissionedTransaction(employeeID, "Matthew", "Home", 1000.0, 3.2);
            transaction1.Execute();

            ChangeSalariedTransaction transaction2 = new ChangeSalariedTransaction(employeeID, 1150.0);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is SalariedPaymentClassification);
            SalariedPaymentClassification salariedClassification = paymentClassification as SalariedPaymentClassification;
            Assert.Equal(1150.0, salariedClassification.Salary, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is MonthlyPaymentSchedule);
        }

        [Fact]
        public void TestChangeCommissionedTransaction()
        {
            Int32 employeeID = 12;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Matthew", "Home", 15.25);
            transaction1.Execute();

            ChangeCommissionedTransaction transaction2 = new ChangeCommissionedTransaction(employeeID, 1200.0, 2.5);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.PaymentClassification;
            Assert.True(paymentClassification is CommissionedPaymentClassification);
            CommissionedPaymentClassification commissionedClassification = paymentClassification as CommissionedPaymentClassification;
            Assert.Equal(1200.0, commissionedClassification.Salary, 3);
            Assert.Equal(2.5, commissionedClassification.CommissionRate, 3);

            IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
            Assert.True(paymentSchedule is BiweeklyPaymentSchedule);
        }

        [Fact]
        public void TestChangeDirectTransaction()
        {
            Int32 employeeID = 13;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Matthew", "Home", 15.25);
            transaction1.Execute();

            ChangeDirectTransaction transaction2 = new ChangeDirectTransaction(employeeID, "Bank of America", "123-456-789");
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is DirectMethod);
        }

        [Fact]
        public void TestChangeMailTransaction()
        {
            Int32 employeeID = 14;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Matthew", "Home", 15.25);
            transaction1.Execute();

            ChangeMailTransaction transaction2 = new ChangeMailTransaction(employeeID, "132 S. Central St. Middle Village, NY 11379");
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is MailMethod);
        }

        [Fact]
        public void TestChangeHoldTransaction()
        {
            Int32 employeeID = 15;
            AddHourlyTransaction transaction1 = new AddHourlyTransaction(employeeID, "Matthew", "Home", 15.25);
            transaction1.Execute();

            ChangeHoldTransaction transaction2 = new ChangeHoldTransaction(employeeID);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentMethod paymentMethod = employee.PaymentMethod;
            Assert.True(paymentMethod is HoldMethod);
        }
    }
}