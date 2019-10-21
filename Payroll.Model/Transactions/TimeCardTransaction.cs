using System;
using Payroll.Model.Classifications;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly Int32 _employeeID;

        private readonly DateTime _date;

        private readonly Double _hours;

        public TimeCardTransaction(Int32 employeeID, DateTime date, Double hours)
        {
            _employeeID = employeeID;
            _date = date;
            _hours = hours;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetEmployee(_employeeID);
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