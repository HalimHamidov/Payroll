using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly Double _salary;

        public ChangeSalariedTransaction(Int32 employeeID, Double salary)
            : base(employeeID)
        {
            _salary = salary;
        }

        protected override IPaymentClassification PaymentClassification
        {
            get
            {
                return new SalariedPaymentClassification(_salary);
            }
        }

        protected override IPaymentSchedule PaymentSchedule
        {
            get
            {
                return new MonthlyPaymentSchedule();
            }
        }
    }
}
