using System;
using Payroll.Core.Model.Affilations;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public abstract class ChangeAffilationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffilationTransaction(Int32 employeeID, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
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
