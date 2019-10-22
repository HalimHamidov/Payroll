using System;
using Payroll.Model.Affilations;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
{
    public abstract class ChangeAffilationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffilationTransaction(Int32 employeeID)
            : base(employeeID)
        {
            //
        }

        protected abstract IAffilation Affilation { get; }

        protected override void Change(Employee employee)
        {
            RecordMembership(employee);
            employee.Affilation = Affilation;
        }

        protected abstract void RecordMembership(Employee employee);
    }
}
