using System;
using Payroll.Model.Classifications;
using Payroll.Model.Schedules;

namespace Payroll.Model.Transactions
{
    public class AddCommissionedEmployeeTransaction : AddEmployeeTransaction
    {
        private readonly Double _salary;

        private readonly Double _commissionRate;

        public AddCommissionedEmployeeTransaction(Int32 employeeID, String name, String address, Double salary, Double commissionRate)
            : base (employeeID, name, address)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        protected override IPaymentClassification MakePaymentClassification()
        {
            return new CommissionedPaymentClassification(_salary, _commissionRate);
        }

        protected override IPaymentSchedule MakePaymentSchedule()
        {
            return new BiweeklyPaymentSchedule();
        }
    }
}