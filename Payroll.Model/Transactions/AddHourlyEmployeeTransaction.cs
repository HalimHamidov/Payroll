using System;
using Payroll.Model.Classifications;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public class AddHourlyEmployeeTransaction : AddEmployeeTransaction
    {
        private readonly Double _hourlyRate;

        public AddHourlyEmployeeTransaction(Int32 employeeID, String name, String address, Double hourlyRate)
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