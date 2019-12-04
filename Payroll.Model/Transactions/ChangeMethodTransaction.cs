using System;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.Methods;

namespace Payroll.Core.Model.Transactions
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangeMethodTransaction(Int32 employeeID)
            : base(employeeID)
        {
            //
        }

        protected abstract IPaymentMethod PaymentMethod { get; }

        protected override void Change(Employee employee)
        {
            employee.PaymentMethod = PaymentMethod;
        }
    }
}
