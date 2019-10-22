using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model.Affilations;
using Payroll.Model.DataContexts;
using Payroll.Model.Entities;

namespace Payroll.Model.Transactions
{
    public class ChangeUnaffilatedTransaction : ChangeAffilationTransaction
    {
        public ChangeUnaffilatedTransaction(Int32 employeeID)
            : base(employeeID)
        {
            //
        }

        protected override IAffilation Affilation
        {
            get
            {
                return new NoAffilation();
            }
        }

        protected override void RecordMembership(Employee employee)
        {
            IAffilation affilation = employee.Affilation;

            if (affilation is UnionAffilation unionAffilation)
            {
                Int32 unionMemberID = unionAffilation.UnionMemberID;
                PayrollDatabase.DeleteUnionMember(unionMemberID);
            }
        }
    }
}
