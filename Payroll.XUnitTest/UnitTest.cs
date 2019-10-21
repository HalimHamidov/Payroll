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
            AddSalariedEmployeeTransaction transaction = new AddSalariedEmployeeTransaction(employeeID, "Bob", "Home", 1000.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Bob", employee.Name);

            IPaymentClassification paymentClassification = employee.Classification;
            Assert.True(paymentClassification is SalariedPaymentClassification);
            SalariedPaymentClassification salariedClassification = paymentClassification as SalariedPaymentClassification;
            Assert.Equal(1000.0, salariedClassification.Salary, 3);

            IPaymentSchedule paymentSchedule = employee.Schedule;
            Assert.True(paymentSchedule is MonthlyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.Method;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestAddHourlyEmployee()
        {
            Int32 employeeID = 2;
            AddHourlyEmployeeTransaction transaction = new AddHourlyEmployeeTransaction(employeeID, "Michael", "Home", 100.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Michael", employee.Name);

            IPaymentClassification paymentClassification = employee.Classification;
            Assert.True(paymentClassification is HourlyPaymentClassification);
            HourlyPaymentClassification hourlyClassification = paymentClassification as HourlyPaymentClassification;
            Assert.Equal(100.0, hourlyClassification.HourlyRate, 3);

            IPaymentSchedule paymentSchedule = employee.Schedule;
            Assert.True(paymentSchedule is WeeklyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.Method;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestAddCommissionedEmployee()
        {
            Int32 employeeID = 3;
            AddCommissionedEmployeeTransaction transaction = new AddCommissionedEmployeeTransaction(employeeID, "Jacob", "Home", 1000.0, 10.0);
            transaction.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Jacob", employee.Name);

            IPaymentClassification paymentClassification = employee.Classification;
            Assert.True(paymentClassification is CommissionedPaymentClassification);
            CommissionedPaymentClassification commissionedClassification = paymentClassification as CommissionedPaymentClassification;
            Assert.Equal(1000.0, commissionedClassification.Salary, 3);
            Assert.Equal(10.0, commissionedClassification.CommissionRate, 3);

            IPaymentSchedule paymentSchedule = employee.Schedule;
            Assert.True(paymentSchedule is BiweeklyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.Method;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }

        [Fact]
        public void TestDeleteEmployee()
        {
            Int32 employeeID = 4;
            AddCommissionedEmployeeTransaction transaction1 = new AddCommissionedEmployeeTransaction(employeeID, "William", "Home", 2500.0, 3.2);
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
            AddHourlyEmployeeTransaction transaction1 = new AddHourlyEmployeeTransaction(employeeID, "Bill", "Home", 15.25);
            transaction1.Execute();

            TimeCardTransaction transaction2 = new TimeCardTransaction(employeeID, new DateTime(2019, 1, 1), 8.0);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.Classification;
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
            AddCommissionedEmployeeTransaction transaction1 = new AddCommissionedEmployeeTransaction(employeeID, "James", "Home", 1000.0, 3.2);
            transaction1.Execute();

            SalesReceiptTransaction transaction2 = new SalesReceiptTransaction(employeeID, new DateTime(2019, 1, 1), 100.0);
            transaction2.Execute();

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.NotNull(employee);

            IPaymentClassification paymentClassification = employee.Classification;
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
            AddSalariedEmployeeTransaction transaction1 = new AddSalariedEmployeeTransaction(employeeID, "Daniel", "Home", 1000.0);
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
    }
}
