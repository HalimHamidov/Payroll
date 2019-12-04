using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public class AddHourlyTransaction : AddEmployeeTransaction
    {
        private readonly Double _hourlyRate;

        public AddHourlyTransaction(Int32 employeeID, String name, String address, Double hourlyRate)
            : base (employeeID, name, address)
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