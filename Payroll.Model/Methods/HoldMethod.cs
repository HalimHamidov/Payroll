using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Methods
{
    public class HoldMethod : IPaymentMethod
    {
        public HoldMethod()
        {
            //
        }

        public void Pay(Paycheck paycheck)
        {
            paycheck.SetField("Disposition", "Hold");
        }
    }
}