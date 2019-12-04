using System;
using Payroll.Core.Model.DataContexts;

namespace Payroll.Core.Model.Transactions
{
    public class DeleteEmployeeTransaction : BaseTransaction
    {
        private readonly Int32 _employeeID;

        public DeleteEmployeeTransaction(Int32 employeeID, IPayrollDatabase dbContext)
            : base (dbContext)
        {
            _employeeID = employeeID;
        }

        public override void Execute()
        {
            _dbContext.DeleteEmployee(_employeeID);
        }
    }
}