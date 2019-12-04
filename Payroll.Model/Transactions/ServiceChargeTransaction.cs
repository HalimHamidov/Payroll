using System;
using Payroll.Core.Model.Entities;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Affilations;

namespace Payroll.Core.Model.Transactions
{
    public class ServiceChargeTransaction : ITransaction
    {
        private readonly Int32 _unionMemberID;

        private readonly DateTime _date;

        private readonly Double _amount;

        public ServiceChargeTransaction(Int32 unionMemberID, DateTime date, Double amount)
        {
            _unionMemberID = unionMemberID;
            _date = date;
            _amount = amount;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetUnionMember(_unionMemberID);
            if (employee != null)
            {
                if (employee.Affilation is UnionAffilation unionAffilation)
                {
                    unionAffilation.AddServiceCharge(new ServiceCharge(_date, _amount));
                }
                else
                {
                    throw new InvalidOperationException("Попытка добавить плату за услуги члена профсоюза с незарегистрированным членством");
                }
            }
            else
            {
                throw new InvalidOperationException("Член профсоюза не найден.");
            }
        }
    }
}