using System;
using Xunit;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;
using Payroll.Model.Transactions;

namespace Payroll.Tests
{
    public class PayrollTests
    {
        public PayrollTests()
        {
            //
        }

        // [Fact]
        // public void TestAddEmployee()
        // {
        //     Employee employee1 = new Employee()
        //     {
        //         ID = 1,
        //         Name = "Employee1"
        //     };

        //     _payrollDatabase.AddEmployee(employee1.ID, employee1);

        //     Employee employee2 = _payrollDatabase.GetEmployee(employee1.ID);

        //     Assert.Equal(employee1.ID, employee2.ID);
        //     Assert.Equal(employee1, employee2);
        // }

        [Fact]
        public void TestAddSalariedEmployee()
        {
            Int32 employeeID = 1;
            AddSalariedEmployeeTransaction transaction = new AddSalariedEmployeeTransaction(employeeID, "Bob", "Home", 1000.0);

            Employee employee = PayrollDatabase.GetEmployee(employeeID);
            Assert.Equal("Bob", employee.Name);
        }
    }
}