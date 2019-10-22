using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.Affilations
{
    public class UnionAffilation : IAffilation
    {
        private readonly Int32 _unionMemberID;

        private readonly Double _dues;

        private readonly ICollection<ServiceCharge> _serviceCharges;

        public UnionAffilation(Int32 unionMemberID, Double dues)
        {
            _unionMemberID = unionMemberID;
            _dues = dues;
            _serviceCharges = new List<ServiceCharge>();
        }

        public Int32 UnionMemberID
        {
            get
            {
                return _unionMemberID;
            }
        }

        public Double Dues
        {
            get
            {
                return _dues;
            }
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            _serviceCharges.Add(serviceCharge);
        }

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            foreach (ServiceCharge serviceCharge in _serviceCharges)
            {
                if (serviceCharge.Date == date)
                {
                    return serviceCharge;
                }
            }

            return null;
        }
    }
}