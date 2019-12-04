using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Core.Model.Transactions;

namespace Payroll.Console.Model.TransactionParsers
{
    public class ChangeEmployeeTransactionParser : ITransactionTextParser
    {
        public ITransaction Parse(String text)
        {
            String[] words = text
                .Split(' ');

            if (words.Length < 3)
            {
                return null;
            }

            ITransaction transaction = null;

            Int32 employeeID = Int32.Parse(words[1]);

            String fieldName = words[2];

            switch (fieldName)
            {
                case "Name":
                    {
                        String name = words[3];
                        transaction = new ChangeNameTransaction(employeeID, name);
                        break;
                    }
                case "Address":
                    {
                        String address = words[3];
                        transaction = new ChangeAddressTransaction(employeeID, address);
                        break;
                    }

                case "Hourly":
                    {
                        Double hourlyRate = Double.Parse(words[3]);
                        transaction = new ChangeHourlyTransaction(employeeID, hourlyRate);
                        break;
                    }
                case "Salaried":
                    {
                        Double salary = Double.Parse(words[3]);
                        transaction = new ChangeSalariedTransaction(employeeID, salary);
                        break;
                    }
                case "Commissioned":
                    {
                        Double salary = Double.Parse(words[3]);
                        Double commissionRate = Double.Parse(words[4]);
                        transaction = new ChangeCommissionedTransaction(employeeID, salary, commissionRate);
                        break;
                    }

                case "Hold":
                    {
                        transaction = new ChangeHoldTransaction(employeeID);
                        break;
                    }
                case "Direct":
                    {
                        String bank = words[3];
                        String account = words[4];
                        transaction = new ChangeDirectTransaction(employeeID, bank, account);
                        break;
                    }
                case "Mail":
                    {
                        String address = words[3];
                        transaction = new ChangeMailTransaction(employeeID, address);
                        break;
                    }

                case "Member":
                    {
                        Int32 unionMemberID = Int32.Parse(words[3]);
                        Double dues = Double.Parse(words[5]);
                        transaction = new ChangeMemberTransaction(employeeID, unionMemberID, dues);
                        break;
                    }
                case "NoMember":
                    {
                        transaction = new ChangeUnaffilatedTransaction(employeeID);
                        break;
                    }
            }

            return transaction;
        }
    }
}
