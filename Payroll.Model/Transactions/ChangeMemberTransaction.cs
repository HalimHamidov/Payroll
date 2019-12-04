using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Affilations;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Entities;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeMemberTransaction : ChangeAffilationTransaction
    {
        private readonly Int32 _unionMemberID;

        private readonly Double _dues;

        public ChangeMemberTransaction(Int32 employeeID, Int32 unionMemberID, Double dues)
            : base(employeeID)
        {
            _unionMemberID = unionMemberID;
            _dues = dues;
        }

        protected override IAffilation Affilation
        {
            get
            {
                return new UnionAffilation(_unionMemberID, _dues);
            }
        }

        protected override void RecordMembership(Employee employee)
        {
            PayrollDatabase.AddUnionMember(_unionMemberID, employee);
        }
    }
}
