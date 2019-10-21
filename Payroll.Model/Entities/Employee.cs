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
    }
}