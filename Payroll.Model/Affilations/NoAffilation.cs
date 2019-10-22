using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Affilations
{
    public class NoAffilation : IAffilation
    {
        public Double CalculateDeductions(Paycheck paycheck)
        {
            return 0.0;
        }
    }
}