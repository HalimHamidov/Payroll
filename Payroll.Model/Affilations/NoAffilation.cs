using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Affilations
{
    public class NoAffilation : IAffilation
    {
        public Double CalculateDeductions(Paycheck paycheck)
        {
            return 0.0;
        }
    }
}