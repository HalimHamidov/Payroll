using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Methods
{
    public class MailMethod : IPaymentMethod
    {
        private readonly String _address;

        public MailMethod(String address)
        {
            _address = address;
        }

        public void Pay(Paycheck paycheck)
        {
            paycheck.SetField("Disposition", "Mail");
        }
    }
}