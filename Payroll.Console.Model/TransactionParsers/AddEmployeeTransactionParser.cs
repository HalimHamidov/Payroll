using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.DataContexts;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class AddEmployeeTransactionParser : BaseTransactionTextParser
    {
        public AddEmployeeTransactionParser(IPayrollDatabase dbContext)
            : base(dbContext)
        {
            //
        }

        public override ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 6)
            {
                return null;
            }

            ITransaction transaction = null;

            Int32 employeeID = Int32.Parse(words[1]);
            
            String name = words[2];
            
            String address = words[3];

            String classification = words[4];

            switch (classification)
            {
                case "H":
                    {
                        Double hourlyRate = Double.Parse(words[5]);
                        transaction = new AddHourlyTransaction(employeeID, name, address, hourlyRate, _dbContext);
                        break;
                    }
                case "S":
                    {
                        Double salary = Double.Parse(words[5]);
                        transaction = new AddSalariedTransaction(employeeID, name, address, salary, _dbContext);
                        break;
                    }
                case "C":
                    {
                        Double salary = Double.Parse(words[5]);
                        Double commissionRate = Double.Parse(words[6]);
                        transaction = new AddCommissionedTransaction(employeeID, name, address, salary, commissionRate, _dbContext);
                        break;
                    }
            }

            return transaction;
        }
    }
}
