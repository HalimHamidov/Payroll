using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Classifications
{
    public interface IPaymentClassification
    {
        Double CalculatePay(Paycheck paycheck);
    }
}