using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Methods;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(Int32 employeeID, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
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
