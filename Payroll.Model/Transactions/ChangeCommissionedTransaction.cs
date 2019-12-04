using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly Double _salary;

        private readonly Double _commissionRate;


        public ChangeCommissionedTransaction(Int32 employeeID, Double salary, Double commissionRate, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
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
