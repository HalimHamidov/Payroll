using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Methods
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