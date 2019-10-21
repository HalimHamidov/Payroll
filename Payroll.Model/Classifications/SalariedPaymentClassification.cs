using System;

namespace Payroll.Model.Classifications
{
    public class SalariedPaymentClassification : IPaymentClassification
    {
        private readonly Double _salary;

        public SalariedPaymentClassification(Double salary)
        {
            _salary = salary;
        }

        public Double GetSalary()
        {
            return _salary;
        }
    }
}