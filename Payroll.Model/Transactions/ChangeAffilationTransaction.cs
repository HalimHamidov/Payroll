using System;

namespace Payroll.Model.Transactions
{
    public abstract class ChangeAffilationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffilationTransaction(Int32 employeeID)
            : base(employeeID)
        {
        }
    }
}
