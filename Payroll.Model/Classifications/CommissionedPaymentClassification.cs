using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.Classifications
{
    public class CommissionedPaymentClassification : IPaymentClassification
    {
        private readonly Double _salary;

        private readonly Double _commissionRate;

        private readonly ICollection<SalesReceipt> _salesReceipts;

        public CommissionedPaymentClassification(Double salary, Double commissionRate)
        {
            _salary = salary;
            _commissionRate = commissionRate;
            _salesReceipts = new List<SalesReceipt>();
        }

        public Double GetSalary()
        {
            return _salary;
        }

        public Double GetCommissionRate()
        {
            return _commissionRate;
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