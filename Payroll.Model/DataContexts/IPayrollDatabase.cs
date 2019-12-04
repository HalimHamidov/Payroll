using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.DataContexts
{
    public interface IPayrollDatabase
    {
        void AddEmployee(Int32 employeeID, Employee employee);

        Employee GetEmployee(Int32 employeeID);

        void DeleteEmployee(Int32 employeeID);

        IEnumerable<Int32> GetEmployeeIDs();

        void AddUnionMember(Int32 unionMemberID, Employee employee);

        Employee GetUnionMember(Int32 unionMemberID);

        void DeleteUnionMember(Int32 unionMemberID);
    }
}
