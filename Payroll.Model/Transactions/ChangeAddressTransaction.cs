using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private readonly String _address;

        public ChangeAddressTransaction(Int32 employeeID, String address)
            : base(employeeID)
        {
            _address = address;
        }

        protected override void Change(Employee employee)
        {
            employee.Address = _address;
        }
    }
}
