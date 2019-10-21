using System;

namespace Payroll.Model.Entities
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