using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(Int32 employeeID, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
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
