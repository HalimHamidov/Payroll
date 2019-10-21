using System;
using Payroll.Model.Classifications;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
{
    public class SalesReceiptTransaction : ITransaction
    {
        private readonly Int32 _employeeID;

        private readonly DateTime _date;

        private readonly Double _amount;

        public SalesReceiptTransaction(Int32 employeeID, DateTime date, Double amount)
        {
            _employeeID = employeeID;
            _date = date;
            _amount = amount;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetEmployee(_employeeID);
            if (employee != null)
            {
                if (employee.Classification is CommissionedPaymentClassification commisionedClassification)
                {
                    commisionedClassification.AddSalesReceipt(new SalesReceipt(_date, _amount));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить справку о продажах для работника не на комиссионной оплате");
                }
            }
            else
            {
                throw new InvalidOperationException("Работник не найден.");
            }
        }
    }
}