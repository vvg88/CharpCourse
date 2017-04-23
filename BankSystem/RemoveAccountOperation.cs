using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class RemoveAccountOperation : Operation
    {
        public RemoveAccountOperation(Account account, double moneyAmount = 0)
            : base(account, OperationType.RemoveAccount, moneyAmount)
        { }

        protected override bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg)
        {
            if (responsibleEmployee.BankEmployer.Accounts.Remove(Account))
            {
                outMsg = "Счет удален.";
                return true;
            }
            outMsg = "Счет не существует или не был удален!";
            return false;
        }
    }
}
