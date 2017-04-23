using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Account
    {
        public double CurrentBalance { get; private set; }
        public Guid ID { get; }
        public Client Owner { get; }

        public Account(double balance, Client owner)
        {
            CurrentBalance = balance;
            ID = Guid.NewGuid();
            Owner = owner;
        }

        public void AddMoney(double moneyAmount)
        {
            CurrentBalance += moneyAmount;
        }

        public bool WithdrawMoney(double moneyAmount)
        {
            if (moneyAmount <= CurrentBalance)
            {
                CurrentBalance -= moneyAmount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Account ID: {ID}";
        }
    }
}
