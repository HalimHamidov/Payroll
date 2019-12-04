using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Core.Model.Entities
{
    public class Paycheck
    {
        private readonly DateTime _startDate;

        private readonly DateTime _endDate;

        private Double _grossPay;

        private Double _deductions;

        private Double _netPay;

        private readonly Dictionary<String, String> _fields;

        public Paycheck(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            _fields = new Dictionary<String, String>();
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
        }

        public Double GrossPay
        {
            get
            {
                return _grossPay;
            }
            set
            {
                _grossPay = value;
            }
        }

        public Double Deductions
        {
            get
            {
                return _deductions;
            }
            set
            {
                _deductions = value;
            }
        }

        public Double NetPay
        {
            get
            {
                return _netPay;
            }
            set
            {
                _netPay = value;
            }
        }

        public void SetField(String fieldName, String fieldValue)
        {
            _fields[fieldName] = fieldValue;
        }

        public String GetField(String fieldName)
        {
            if (_fields.ContainsKey(fieldName))
            {
                return _fields[fieldName];
            }

            return null;
        }
    }
}
