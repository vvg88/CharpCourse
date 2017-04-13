using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Client : Person
    {
        private List<Account> accounts = new List<Account> { };
        public IReadOnlyList<Account> Accounts
        {
            get { return accounts; }
        }

        public Client(string name, string surname) : base(name, surname)
        { }

        public void CreateAccount(int accId, double sumMoney) => accounts.Add(new Account(sumMoney, accId));

        public bool RemoveAccount(int accId)
        {
            var accnt = accounts.FirstOrDefault(item => item.ID == accId);
            if (accnt == null)
                return false;
            return accounts.Remove(accnt);
        }
    }
}
