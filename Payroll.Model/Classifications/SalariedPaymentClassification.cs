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

        public Double Salary
        {
            get
            {
                return _salary;
            }
        }
    }
}