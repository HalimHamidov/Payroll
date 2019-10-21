using System;
using Payroll.Model.Classifications;
using Payroll.Model.Entities;
using Payroll.Model.Methods;
using Payroll.Model.Schedules;
using Payroll.Model.DataContexts;

namespace Payroll.Model.Transactions
{
    public abstract class AddEmployeeTransaction : ITransaction
    {
        private readonly Int32 _employeeID;

        private readonly String _name;

        private readonly String _address;

        public AddEmployeeTransaction(Int32 employeeID, String name, String address)
        {
            _employeeID = employeeID;
            _name = name;
            _address = address;
        }

        protected abstract IPaymentClassification MakePaymentClassification();

        protected abstract IPaymentSchedule MakePaymentSchedule();

        public void Execute()
        {
            IPaymentClassification pc = MakePaymentClassification();
            IPaymentSchedule ps = MakePaymentSchedule();
            IPaymentMethod pm = new HoldMethod();

            Employee employee = new Employee(_employeeID, _name, _address)
            {
                Classification = pc,
                Schedule = ps,
                Method = pm
            };

            PayrollDatabase.AddEmployee(_employeeID, employee);
        }
    }
}