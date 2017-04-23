using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    [Flags]
    public enum OperationType
    {
        Nothing,
        AddMoney,
        WithdrawMoney = 2,
        CreateAccount = 4,
        RemoveAccount = 8
    }
}
