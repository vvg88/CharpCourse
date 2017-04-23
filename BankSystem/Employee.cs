using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Employee : Person
    {
        public OperationType AccessRight { get; }
        public int ID { get; }
        public bool IsBusy { get; private set; }
        public Bank BankEmployer { get; }

        private System.Timers.Timer serviceTimer = new System.Timers.Timer();

        public Employee(string name, string surName, OperationType accessRight, Bank bankEmployer) : base(name, surName)
        {
            ID = bankEmployer.Employees.Count + 1;
            AccessRight = accessRight;
            BankEmployer = bankEmployer;

            serviceTimer.AutoReset = false;
            serviceTimer.Interval = 1000;
            serviceTimer.Elapsed += (sndr, evArgs) => { IsBusy = false; };
        }

        public bool ProvideService(Operation requiredOperation, out string outMessage)
        {
            IsBusy = true;
            serviceTimer.Start();
            return requiredOperation.RunOperation(this, out outMessage);
        }

        public bool CheckAccessibility(Operation reqOper) => !IsBusy && (reqOper.OperationType & AccessRight) == reqOper.OperationType;
    }
}
