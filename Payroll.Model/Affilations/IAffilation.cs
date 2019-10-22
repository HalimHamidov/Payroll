using System;
using Payroll.Model.Entities;

namespace Payroll.Model.Affilations
{
    public interface IAffilation
    {
        Double CalculateDeductions(Paycheck paycheck);
    }
}