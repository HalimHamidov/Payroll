using System;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public abstract class ChangeEmployeeTransaction : BaseTransaction
    {
        private readonly Int32 _employeeID;

        public ChangeEmployeeTransaction(Int32 employeeID, IPayrollDatabase dbContext)
            : base(dbContext)
        {
            _employeeID = employeeID;
        }

        public override void Execute()
        {
            Employee employee = _dbContext.GetEmployee(_employeeID);
            if (employee != null)
            {
                Change(employee);
            }
            else
            {
                throw new InvalidOperationException("Работник не найден.");
            }
        }

        protected abstract void Change(Employee employee);
    }
}