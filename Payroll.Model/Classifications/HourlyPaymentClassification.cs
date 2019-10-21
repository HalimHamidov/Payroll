using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

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
    }
}