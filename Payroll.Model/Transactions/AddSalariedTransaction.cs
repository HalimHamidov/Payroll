using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Schedules;

namespace Payroll.Core.Model.Transactions
{
    public class AddSalariedTransaction : AddEmployeeTransaction
    {
        private readonly Double _salary;

        public AddSalariedTransaction(Int32 employeeID, String name, String address, Double salary, IPayrollDatabase dbContext)
            : base (employeeID, name, address, dbContext)
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