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

        public String Name { get; private set; }

        public String Address { get; private set; }

        public IPaymentClassification Classification { get; set; }

        public IPaymentSchedule Schedule { get; set;}

        public IPaymentMethod Method { get; set; }

        public IAffilation Affilation { get; set; }
    }
}