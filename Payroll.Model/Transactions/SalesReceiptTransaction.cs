using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class SalesReceiptTransaction : BaseTransaction
    {
        private readonly Int32 _employeeID;

        private readonly DateTime _date;

        private readonly Double _amount;

        public SalesReceiptTransaction(Int32 employeeID, DateTime date, Double amount, IPayrollDatabase dbContext)
            : base (dbContext)
        {
            _employeeID = employeeID;
            _date = date;
            _amount = amount;
        }

        public override void Execute()
        {
            Employee employee = _dbContext.GetEmployee(_employeeID);
            if (employee != null)
            {
                if (employee.PaymentClassification is CommissionedPaymentClassification commisionedClassification)
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