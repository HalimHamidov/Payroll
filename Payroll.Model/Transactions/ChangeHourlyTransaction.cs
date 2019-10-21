using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Classifications;
using Payroll.Model.Entities;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly Double _hourlyRate;

        public ChangeHourlyTransaction(Int32 employeeID, Double hourlyRate)
            : base(employeeID)
        {
            _hourlyRate = hourlyRate;
        }

        protected override IPaymentClassification PaymentClassification
        {
            get
            {
                return new HourlyPaymentClassification(_hourlyRate);
            }
        }

        protected override IPaymentSchedule PaymentSchedule
        {
            get
            {
                return new WeeklyPaymentSchedule();
            }
        }
    }
}
