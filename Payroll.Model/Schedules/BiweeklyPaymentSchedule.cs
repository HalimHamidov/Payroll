using System;

namespace Payroll.Core.Model.Schedules
{
    public class BiweeklyPaymentSchedule : IPaymentSchedule
    {
        public BiweeklyPaymentSchedule()
        {
            //
        }

        public Boolean IsPayDate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-13);
        }
    }
}