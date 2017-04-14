using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Account
    {
        public double CurrentBalance { get; private set; }
        public int ID { get; }
        public Client Owner { get; }

        private static Random idRandomiser = new Random();

        public Account(double balance, Client owner)
        {
            CurrentBalance = balance;
            ID = idRandomiser.Next(0, 1000);
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
    }
}
