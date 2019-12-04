using System;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private readonly String _address;

        public ChangeAddressTransaction(Int32 employeeID, String address, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
        {
            _address = address;
        }

        protected override void Change(Employee employee)
        {
            employee.Address = _address;
        }
    }
}
