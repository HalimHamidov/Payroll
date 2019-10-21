using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.Classifications
{
    public class HourlyPaymentClassification : IPaymentClassification
    {
        private readonly ICollection<TimeCard> _timeCards;

        public HourlyPaymentClassification()
        {
            _timeCards = new List<TimeCard>();
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