using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Methods
{
    public interface IPaymentMethod
    {
        void Pay(Paycheck paycheck);
    }
}