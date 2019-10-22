using System;
using Payroll.Model.Entities;
using Payroll.Model.Methods;

namespace Payroll.Model.Transactions
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
