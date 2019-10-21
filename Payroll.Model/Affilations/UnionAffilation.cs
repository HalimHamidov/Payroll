using System;
using System.Collections;
using System.Collections.Generic;
using Payroll.Model.Entities;

namespace Payroll.Model.Affilations
{
    public class UnionAffilation : IAffilation
    {
        private readonly ICollection<ServiceCharge> _serviceCharges;

        public UnionAffilation()
        {
            _serviceCharges = new List<ServiceCharge>();
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