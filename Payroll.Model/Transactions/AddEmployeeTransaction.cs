using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.Methods;
using Payroll.Core.Model.Schedules;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Affilations;

namespace Payroll.Core.Model.Transactions
{
    public abstract class AddEmployeeTransaction : BaseTransaction
    {
        private readonly Int32 _employeeID;

        private readonly String _name;

        private readonly String _address;

        public AddEmployeeTransaction(Int32 employeeID, String name, String address, IPayrollDatabase dbContext)
            : base (dbContext)
        {
            _employeeID = employeeID;
            _name = name;
            _address = address;
        }

        protected abstract IPaymentClassification PaymentClassification
        {
            get;
        }

        protected abstract IPaymentSchedule PaymentSchedule
        {
            get;
        }

        public override void Execute()
        {
            IPaymentClassification paymentClassification = PaymentClassification;
            IPaymentSchedule paymentSchedule = PaymentSchedule;
            IPaymentMethod paymentMethod = new HoldMethod();
            IAffilation affilation = new NoAffilation();

            Employee employee = new Employee(_employeeID, _name, _address)
            {
                PaymentClassification = paymentClassification,
                PaymentSchedule = paymentSchedule,
                PaymentMethod = paymentMethod,
                Affilation = affilation
            };

            _dbContext.AddEmployee(_employeeID, employee);
        }
    }
}