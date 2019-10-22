using System;

namespace Payroll.Model.Schedules
{
    public class MonthlyPaymentSchedule : IPaymentSchedule
    {
        public MonthlyPaymentSchedule()
        {
            //
        }

        private Boolean IsLastDayOfMonth(DateTime date)
        {
            Int32 month1 = date.Month;
            Int32 month2 = date.AddDays(1).Month;

            return (month1 != month2);
        }

        public Boolean IsPayDate(DateTime date)
        {
            return IsLastDayOfMonth(date);
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
    }
}