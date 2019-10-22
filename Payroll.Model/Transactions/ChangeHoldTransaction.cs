using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Methods;

namespace Payroll.Model.Transactions
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(Int32 employeeID)
            : base(employeeID)
        {
            //
        }

        protected override IPaymentMethod PaymentMethod
        {
            get
            {
                return new HoldMethod();
            }
        }
    }
}
