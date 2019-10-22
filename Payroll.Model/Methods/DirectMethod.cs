using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Methods
{
    public class DirectMethod : IPaymentMethod
    {
        private readonly String _bank;

        private readonly String _account;

        public DirectMethod(String bank, String account)
        {
            _bank = bank;
            _account = account;
        }

        public void Pay(Paycheck paycheck)
        {
            paycheck.SetField("Disposition", "Direct");
        }
    }
}