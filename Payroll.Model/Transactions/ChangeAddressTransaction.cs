using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
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
