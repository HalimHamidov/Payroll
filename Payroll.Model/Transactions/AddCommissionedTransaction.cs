using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public class AddCommissionedTransaction : AddEmployeeTransaction
    {
        private readonly Double _salary;

        private readonly Double _commissionRate;

        public AddCommissionedTransaction(Int32 employeeID, String name, String address, Double salary, Double commissionRate, IPayrollDatabase dbContext)
            : base (employeeID, name, address, dbContext)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        protected override IPaymentClassification PaymentClassification
        {
            get
            {
                return new CommissionedPaymentClassification(_salary, _commissionRate);
            }
        }

        protected override IPaymentSchedule PaymentSchedule
        {
            get
            {
                return new BiweeklyPaymentSchedule();
            }
        }
    }
}