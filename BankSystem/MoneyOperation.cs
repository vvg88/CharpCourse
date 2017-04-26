using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class MoneyOperation : Operation
    {
        public double MoneyAmount { get; private set; }

        public MoneyOperation(Account account, OperationType opType, double moneyAmount) : base(account, opType)
        {
            MoneyAmount = moneyAmount;
        }
    }
}
