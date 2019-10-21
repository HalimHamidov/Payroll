using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.DataContexts
{
    public class PayrollDatabase
    {
        private static readonly Dictionary<Int32, Employee> _employees = new Dictionary<Int32, Employee>();
        private static readonly Dictionary<Int32, Employee> _unionMembers = new Dictionary<Int32, Employee>();

        public static void AddEmployee(Int32 employeeID, Employee employee)
        {
            _employees[employeeID] = employee;
        }

        public static Employee GetEmployee(Int32 employeeID)
        {
            if (_employees.ContainsKey(employeeID))
            {
                return _employees[employeeID];
            }

            return null;
        }

        public static void DeleteEmployee(Int32 employeeID)
        {
            if (_employees.ContainsKey(employeeID))
            {
                _employees.Remove(employeeID);
            }
        }
    
        public static void AddUnionMember(Int32 unionMemberID, Employee employee)
        {
            _unionMembers[unionMemberID] = employee;
        }

        public static Employee GetUnionMember(Int32 unionMemberID)
        {
            if (_unionMembers.ContainsKey(unionMemberID))
            {
                return _unionMembers[unionMemberID];
            }

            return null;
        }

        public static void DeleteUnionMember(Int32 unionMemberID)
        {
            if (_unionMembers.ContainsKey(unionMemberID))
            {
                _unionMembers.Remove(unionMemberID);
            }
        }
    }
}