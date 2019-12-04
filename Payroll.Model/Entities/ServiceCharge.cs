using System;

namespace Payroll.Core.Model.Entities
{
    public class ServiceCharge
    {
        public ServiceCharge(DateTime date, Double amount)
        {
            Date = date;
            Amount = amount;
        }

        public DateTime Date { get; private set; }

        public Double Amount { get; private set; }
    }
}