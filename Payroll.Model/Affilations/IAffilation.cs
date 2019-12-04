using System;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Affilations
{
    public interface IAffilation
    {
        Double CalculateDeductions(Paycheck paycheck);
    }
}