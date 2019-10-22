using System;

namespace Payroll.Model.Schedules
{
    public class WeeklyPaymentSchedule : IPaymentSchedule
    {
        public WeeklyPaymentSchedule()
        {
            //
        }

        public Boolean IsPayDate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-6);
        }
    }
}