using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class CreateAccountOperation : Operation
    {
        public CreateAccountOperation(Account account)
            : base(account, OperationType.CreateAccount)
        { }

        protected override bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg)
        {
            responsibleEmployee.BankEmployer.Accounts.Add(Account);
            outMsg = "Создан счет.";
            return true;
        }
    }
}
