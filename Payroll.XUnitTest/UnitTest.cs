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
            Assert.Equal(1000.0, salariedClassification.GetSalary(), 3);

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
            Assert.Equal(100.0, hourlyClassification.GetHourlyRate(), 3);

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
            Assert.Equal(1000.0, commissionedClassification.GetSalary(), 3);
            Assert.Equal(10.0, commissionedClassification.GetCommissionRate(), 3);

            IPaymentSchedule paymentSchedule = employee.Schedule;
            Assert.True(paymentSchedule is BiweeklyPaymentSchedule);

            IPaymentMethod paymentMethod = employee.Method;
            Assert.True(paymentMethod is HoldMethod);

            IAffilation affilation = employee.Affilation;
            Assert.True(affilation is NoAffilation);
        }
    }
}
