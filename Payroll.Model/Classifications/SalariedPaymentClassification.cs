using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Classifications
{
    public class SalariedPaymentClassification : IPaymentClassification
    {
        private readonly Double _salary;

        public SalariedPaymentClassification(Double salary)
        {
            _salary = salary;
        }

        public Double Salary
        {
            get
            {
                return _salary;
            }
        }

        public Double CalculatePay(Paycheck paycheck)
        {
            return _salary;
        }
    }
}