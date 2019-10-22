using System;
using Payroll.Model.Affilations;
using Payroll.Model.Classifications;
using Payroll.Model.Methods;
using Payroll.Model.Schedules;

namespace Payroll.Model.Entities
{
    public class Employee
    {
        public Employee(Int32 employeeID, String name, String address)
        {
            ID = employeeID;
            Name = name;
            Address = address;
        }

        public Int32 ID { get; private set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public IPaymentClassification PaymentClassification { get; set; }

        public IPaymentSchedule PaymentSchedule { get; set;}

        public IPaymentMethod PaymentMethod { get; set; }

        public IAffilation Affilation { get; set; }

        public Boolean IsPayDate(DateTime date)
        {
            return PaymentSchedule.IsPayDate(date);
        }

        public void Payday(Paycheck paycheck)
        {
            Double grossPay = PaymentClassification.CalculatePay(paycheck);
            Double deductions = Affilation.CalculateDeductions(paycheck);
            Double netPay = grossPay - deductions;

            paycheck.GrossPay = grossPay;
            paycheck.Deductions = deductions;
            paycheck.NetPay = netPay;

            PaymentMethod.Pay(paycheck);
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return PaymentSchedule.GetPayPeriodStartDate(date);
        }
    }
}