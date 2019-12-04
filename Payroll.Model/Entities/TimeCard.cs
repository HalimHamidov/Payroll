using System;

namespace Payroll.Core.Model.Entities
{
    public class TimeCard
    {
        public TimeCard(DateTime date, Double hours)
        {
            Date = date;
            Hours = hours;
        }

        public DateTime Date { get; private set; }

        public Double Hours { get; private set; }
    }
}