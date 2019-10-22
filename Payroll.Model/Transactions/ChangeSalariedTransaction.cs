using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Classifications;
using Payroll.Model.Entities;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
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
