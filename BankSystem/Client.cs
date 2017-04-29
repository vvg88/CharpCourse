using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Client : Person
    {
        public Bank BankServiceProvider { get; }

        public Client(string name, string surname, Bank bankServiceProvider) : base(name, surname)
        {
            BankServiceProvider = bankServiceProvider;
        }

        public IEnumerable<Account> Accounts
        {
            get
            {
                return from acc in BankServiceProvider.Accounts
                       where acc.Owner == this
                       select acc;
            }
        }
    }
}
