using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Methods;

namespace Payroll.Core.Model.Transactions
{
    public class ChangeMailTransaction : ChangeMethodTransaction
    {
        private readonly String _address;

        public ChangeMailTransaction(Int32 employeeID, String address, IPayrollDatabase dbContext)
            : base(employeeID, dbContext)
        {
            _address = address;
        }

        protected override IPaymentMethod PaymentMethod
        {
            get
            {
                return new MailMethod(_address);
            }
        }
    }
}
