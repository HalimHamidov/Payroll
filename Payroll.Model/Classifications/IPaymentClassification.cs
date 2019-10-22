using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Classifications
{
    public interface IPaymentClassification
    {
        Double CalculatePay(Paycheck paycheck);
    }
}