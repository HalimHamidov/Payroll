using System;

namespace Payroll.Model.Schedules
{
    public interface IPaymentSchedule
    {
        Boolean IsPayDate(DateTime date);

        DateTime GetPayPeriodStartDate(DateTime date);
    }
}