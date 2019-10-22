using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Methods
{
    public interface IPaymentMethod
    {
        void Pay(Paycheck paycheck);
    }
}