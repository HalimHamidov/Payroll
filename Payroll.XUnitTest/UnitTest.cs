using System;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;
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
        }
    }
}
