using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Operation
    {
        public Account Account { get; }
        public OperationType OperationType { get; } = OperationType.Nothing;
        public double MoneyAmount { get; set; }

        public Operation(Account account, OperationType opType, double moneyAmount)
        {
            Account = account;
            OperationType = opType;
            MoneyAmount = moneyAmount;
        }
    }
}
