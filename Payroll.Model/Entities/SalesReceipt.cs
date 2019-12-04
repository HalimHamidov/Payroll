using System;

namespace Payroll.Core.Model.Entities
{
    public class SalesReceipt
    {
        public SalesReceipt(DateTime date, Double amount)
        {
            Date = date;
            Amount = amount;
        }

        public DateTime Date { get; private set; }

        public Double Amount { get; private set; }
    }
}