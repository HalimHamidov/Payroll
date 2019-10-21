using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.Classifications
{
    public class ComissionedPaymentClassification : IPaymentClassification
    {
        private readonly ICollection<SalesReceipt> _salesReceipts;

        public ComissionedPaymentClassification()
        {
            _salesReceipts = new List<SalesReceipt>();
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            _salesReceipts.Add(salesReceipt);
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            foreach (SalesReceipt salesReceipt in _salesReceipts)
            {
                if (salesReceipt.Date == date)
                {
                    return salesReceipt;
                }
            }

            return null;
        }
    }
}