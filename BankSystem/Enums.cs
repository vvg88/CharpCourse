using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public enum OperationType { Nothing, AddMoney, WithdrawMoney, CreateAccount, RemoveAccount }

    public enum OperationAccessRights { AddWithdraw, AddWithdrawCreateRemove }
}
