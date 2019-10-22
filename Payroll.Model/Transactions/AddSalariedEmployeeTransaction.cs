using System;
using Payroll.Model.Classifications;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public class AddSalariedEmployeeTransaction : AddEmployeeTransaction
    {
        private readonly Double _salary;

        public AddSalariedEmployeeTransaction(Int32 employeeID, String name, String address, Double salary)
            : base (employeeID, name, address)
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