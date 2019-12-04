using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.DataContexts
{
    public class InMemoryPayrollDatabase : IPayrollDatabase
    {
        private readonly Dictionary<Int32, Employee> _employees;
        private readonly Dictionary<Int32, Employee> _unionMembers;

        public InMemoryPayrollDatabase()
        {
            _employees = new Dictionary<Int32, Employee>();
            _unionMembers = new Dictionary<Int32, Employee>();
        }

        public void AddEmployee(Int32 employeeID, Employee employee)
        {
            _employees[employeeID] = employee;
        }

        public Employee GetEmployee(Int32 employeeID)
        {
            if (_employees.ContainsKey(employeeID))
            {
                return _employees[employeeID];
            }

            return null;
        }

        public void DeleteEmployee(Int32 employeeID)
        {
            if (_employees.ContainsKey(employeeID))
            {
                _employees.Remove(employeeID);
            }
        }

        public IEnumerable<Int32> GetEmployeeIDs()
        {
            return _employees.Keys;
        }
    
        public void AddUnionMember(Int32 unionMemberID, Employee employee)
        {
            _unionMembers[unionMemberID] = employee;
        }

        public Employee GetUnionMember(Int32 unionMemberID)
        {
            if (_unionMembers.ContainsKey(unionMemberID))
            {
                return _unionMembers[unionMemberID];
            }

            return null;
        }

        public void DeleteUnionMember(Int32 unionMemberID)
        {
            if (_unionMembers.ContainsKey(unionMemberID))
            {
                _unionMembers.Remove(unionMemberID);
            }
        }
    }
}