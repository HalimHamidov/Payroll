using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly String _name;

        public ChangeNameTransaction(Int32 employeeID, String name)
            : base(employeeID)
        {
            _name = name;
        }

        protected override void Change(Employee employee)
        {
            employee.Name = _name;
        }
    }
}
