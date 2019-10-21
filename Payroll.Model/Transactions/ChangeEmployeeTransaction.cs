using System;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
{
    public abstract class ChangeEmployeeTransaction : ITransaction
    {
        private readonly Int32 _employeeID;

        public ChangeEmployeeTransaction(Int32 employeeID)
        {
            _employeeID = employeeID;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetEmployee(_employeeID);
        }
    }
}