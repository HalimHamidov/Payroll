using System;
using Payroll.Core.Model.DataContexts;

namespace Payroll.Core.Model.Transactions
{
    public class DeleteEmployeeTransaction : ITransaction
    {
        private readonly Int32 _employeeID;

        public DeleteEmployeeTransaction(Int32 employeeID)
        {
            _employeeID = employeeID;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(_employeeID);
        }
    }
}