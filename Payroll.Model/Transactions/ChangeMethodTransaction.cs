using System;

namespace Payroll.Model.Transactions
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangeMethodTransaction(Int32 employeeID)
            : base(employeeID)
        {
        }
    }
}
