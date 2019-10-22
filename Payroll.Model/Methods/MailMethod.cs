using System;

namespace Payroll.Model.Methods
{
    public class MailMethod : IPaymentMethod
    {
        private readonly String _address;

        public MailMethod(String address)
        {
            _address = address;
        }
    }
}