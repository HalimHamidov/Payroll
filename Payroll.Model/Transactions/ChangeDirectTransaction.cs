using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Methods;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeDirectTransaction : ChangeMethodTransaction
    {
        private readonly String _bank;

        private readonly String _account;

        public ChangeDirectTransaction(Int32 employeeID, String bank, String account, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
        {
            _bank = bank;
            _account = account;
        }

        protected override IPaymentMethod PaymentMethod
        {
            get
            {
                return new DirectMethod(_bank, _account);
            }
        }
    }
}
