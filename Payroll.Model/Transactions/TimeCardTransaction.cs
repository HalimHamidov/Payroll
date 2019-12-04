using System;
using Payroll.Core.Model.Classifications;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class TimeCardTransaction : BaseTransaction
    {
        private readonly Int32 _employeeID;

        private readonly DateTime _date;

        private readonly Double _hours;

        public TimeCardTransaction(Int32 employeeID, DateTime date, Double hours, IPayrollDatabase dbContext)
            : base(dbContext)
        {
            _employeeID = employeeID;
            _date = date;
            _hours = hours;
        }

        public override void Execute()
        {
            Employee employee = _dbContext.GetEmployee(_employeeID);
            if (employee != null)
            {
                if (employee.PaymentClassification is HourlyPaymentClassification hourlyClassification)
                {
                    hourlyClassification.AddTimeCard(new TimeCard(_date, _hours));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить карточку табельного учёта для работника не на почасовой оплате");
                }
            }
            else
            {
                throw new InvalidOperationException("Работник не найден.");
            }
        }
    }
}