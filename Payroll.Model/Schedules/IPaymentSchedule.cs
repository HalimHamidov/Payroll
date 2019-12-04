using System;

namespace Payroll.Core.Model.Schedules
{
    public interface IPaymentSchedule
    {
        Boolean IsPayDate(DateTime date);

        DateTime GetPayPeriodStartDate(DateTime date);
    }
}