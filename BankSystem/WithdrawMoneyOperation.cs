using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class WithdrawMoneyOperation : MoneyOperation
    {
        public WithdrawMoneyOperation(Account account, double moneyAmount)
            : base(account, OperationType.AddMoney, moneyAmount)
        { }

        protected override bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg)
        {
            if (Account.WithdrawMoney(MoneyAmount))
            {
                outMsg = "Средства списаны со счета.";
                return true;
            }
            else
            {
                outMsg = "Не достаточно средств на счете!";
                return false;
            }
        }
    }
}
