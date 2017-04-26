using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class AddMoneyOperation : MoneyOperation
    {
        public AddMoneyOperation(Account account, double moneyAmount)
            : base(account, OperationType.AddMoney, moneyAmount)
        { }

        protected override bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg)
        {
            Account.AddMoney(MoneyAmount);
            outMsg = "Средства зачислены на счет.";
            return true;
        }
    }
}
