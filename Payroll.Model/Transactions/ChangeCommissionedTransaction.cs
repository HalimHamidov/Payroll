using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Classifications;
using Payroll.Model.Entities;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly Double _salary;

        private readonly Double _commissionRate;


        public ChangeCommissionedTransaction(Int32 employeeID, Double salary, Double commissionRate)
            : base(employeeID)
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
