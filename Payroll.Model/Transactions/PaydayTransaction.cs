using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class PaydayTransaction : ITransaction
    {
        private readonly DateTime _date;

        private readonly Dictionary<Int32, Paycheck> _paychecks;

        public PaydayTransaction(DateTime date)
        {
            _date = date;
            _paychecks = new Dictionary<Int32, Paycheck>();
        }

        public void Execute()
        {
            IEnumerable<Int32> employeeIDs = PayrollDatabase.GetEmployeeIDs();
            foreach(Int32 employeeID in employeeIDs)
            {
                Employee employee = PayrollDatabase.GetEmployee(employeeID);
                if (employee.IsPayDate(_date))
                {
                    DateTime startDate = employee.GetPayPeriodStartDate(_date);
                    DateTime endDate = _date;

                    Paycheck paycheck = new Paycheck(startDate, endDate);
                    employee.Payday(paycheck);

                    _paychecks[employeeID] = paycheck;
                }
            }
        }

        public Paycheck GetPaycheck(Int32 employeeID)
        {
            if (_paychecks.ContainsKey(employeeID))
            {
                return _paychecks[employeeID];
            }

            return null;
        }
    }
}
