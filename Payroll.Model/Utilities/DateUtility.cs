using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Core.Model.Utilities
{
    public class DateUtility
    {
        public static Boolean IsInPeriod(DateTime date, DateTime startDate, DateTime endDate)
        {
            return (date >= startDate && date <= endDate);
        }

        public static Int32 NumberOfDaysOfWeekInPeriod(DayOfWeek dayOfWeek, DateTime startDate, DateTime endDate)
        {
            Int32 days = 0;

            for (DateTime day = startDate; day <= endDate; day = day.AddDays(1))
            {
                if (day.DayOfWeek == dayOfWeek)
                {
                    days++;
                }
            }

            return days;
        }
    }
}
