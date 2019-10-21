using System;
using Payroll.Model.Classifications;
using Payroll.Model.Entities;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(Int32 employeeID)
            : base(employeeID)
        {
            //
        }

        protected abstract IPaymentClassification PaymentClassification { get; }

        protected abstract IPaymentSchedule PaymentSchedule { get; }

        protected override void Change(Employee employee)
        {
            employee.PaymentClassification = PaymentClassification;
            employee.PaymentSchedule = PaymentSchedule;
        }
    }
}
