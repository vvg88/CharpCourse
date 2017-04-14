﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Employee : Person
    {
        public OperationAccessRights AccessRight { get; }

        public int ID { get; }

        public bool IsBusy { get; private set; }

        public Bank BankEmployer { get; }

        private System.Timers.Timer serviceTimer = new System.Timers.Timer();

        public Employee(string name, string surName, int id, OperationAccessRights accessRight, Bank bankEmployer) : base (name, surName)
        {
            ID = id;
            AccessRight = accessRight;
            BankEmployer = bankEmployer;

            serviceTimer.AutoReset = false;
            serviceTimer.Interval = 1000;
            serviceTimer.Elapsed += (sndr, evArgs) => { IsBusy = false; };
        }

        public bool ProvideService(Client client, out string outMessage)
        {
            switch (client.RequiredOperation.OperationType)
            {
                case OperationType.AddMoney:
                    client.RequiredOperation.Account.AddMoney(client.RequiredOperation.MoneyAmount);
                    outMessage = "Средства зачислены на счет.";
                    serviceTimer.Start();
                    break;
                case OperationType.WithdrawMoney:
                    serviceTimer.Start();
                    if (client.RequiredOperation.Account.WithdrawMoney(client.RequiredOperation.MoneyAmount))
                    {
                        outMessage = "Средства списаны со счета.";
                    }
                    else
                    {
                        outMessage = "Недостаточно средств на счете.";
                        return false;
                    }
                    break;
                case OperationType.CreateAccount:
                    serviceTimer.Start();
                    (BankEmployer.Accounts as IList<Account>)?.Add(new Account(client.RequiredOperation.MoneyAmount, client));
                    outMessage = "Создан новый счет.";
                    break;
                case OperationType.RemoveAccount:
                    serviceTimer.Start();
                    (BankEmployer.Accounts as IList<Account>)?.Remove(client.RequiredOperation.Account);
                    outMessage = "Счет удален!";
                    break;
                default:
                    outMessage = "Клиенту ничего не нужно!";
                    return false;
            }
            return true;
        }
    }
}
