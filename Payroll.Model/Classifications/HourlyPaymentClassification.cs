using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;
using Payroll.Model.Utilities;

namespace Payroll.Model.Classifications
{
    public class HourlyPaymentClassification : IPaymentClassification
    {
        private readonly Double _hourlyRate;

        private readonly ICollection<TimeCard> _timeCards;

        public HourlyPaymentClassification(Double hourlyRate)
        {
            _hourlyRate = hourlyRate;
            _timeCards = new List<TimeCard>();
        }

        public Double HourlyRate
        {
            get
            {
                return _hourlyRate;
            }
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            _timeCards.Add(timeCard);
        }

        public TimeCard GetTimeCard(DateTime date)
        {
            foreach (TimeCard timeCard in _timeCards)
            {
                if (timeCard.Date == date)
                {
                    return timeCard;
                }
            }

            return null;
        }

        public Double CalculatePay(Paycheck paycheck)
        {
            Double totalPay = 0.0;

            foreach (TimeCard timeCard in _timeCards)
            {
                if (DateUtility.IsInPeriod(timeCard.Date, paycheck.StartDate, paycheck.EndDate))
                {
                    totalPay += CalculatePayForTimeCard(timeCard);
                }
            }

            return totalPay;
        }

        private Double CalculatePayForTimeCard(TimeCard timeCard)
        {
            Double overtimeHours = Math.Max(0.0, timeCard.Hours - 8.0);
            Double normalHours = timeCard.Hours - overtimeHours;

            return _hourlyRate * (normalHours + 1.5 * overtimeHours);
        }
    }
}