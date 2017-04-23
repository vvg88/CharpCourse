using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class CreateAccountOperation : Operation
    {
        public CreateAccountOperation(Account account, double moneyAmount = 0)
            : base(account, OperationType.CreateAccount, moneyAmount)
        { }

        protected override bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg)
        {
            responsibleEmployee.BankEmployer.Accounts.Add(Account);
            outMsg = "Создан счет.";
            return true;
        }
    }
}
