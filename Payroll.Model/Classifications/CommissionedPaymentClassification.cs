using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;
using Payroll.Model.Utilities;

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

        public Double Salary
        {
            get
            {
                return _salary;
            }
        }

        public Double CommissionRate
        {
            get
            {
                return _commissionRate;
            }
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

        public Double CalculatePay(Paycheck paycheck)
        {
            Double totalPay = _salary;

            foreach (SalesReceipt salesReceipt in _salesReceipts)
            {
                if (DateUtility.IsInPeriod(salesReceipt.Date, paycheck.StartDate, paycheck.EndDate))
                {
                    totalPay += CalculatePayForSalesReceipt(salesReceipt);
                }
            }

            return totalPay;
        }

        private Double CalculatePayForSalesReceipt(SalesReceipt salesReceipt)
        {
            return _commissionRate * salesReceipt.Amount;
        }

    }
}