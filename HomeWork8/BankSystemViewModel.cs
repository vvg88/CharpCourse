using BankSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork8
{
    class BankSystemViewModel
    {
        private Bank someBank;

        public ObservableCollection<Employee> Employees { get; }

        public ObservableCollection<OperationAccessRights> AccountOperationRights { get; }

        public string NewEmployeeName { get; set; }
        public string NewEmployeeSurname { get; set; }
        public OperationAccessRights NewEmplAccessRight { get; set; }

        public BankSystemViewModel()
        {
            someBank = new Bank();
            Employees = new ObservableCollection<Employee>
            {
                new Employee("Иван", "Иванов", OperationAccessRights.AddWithdraw, someBank),
                new Employee("Петр", "Петров", OperationAccessRights.AddWithdraw, someBank),
                new Employee("Алексей", "Алексеев", OperationAccessRights.AddWithdrawCreateRemove, someBank)
            };

            AccountOperationRights = new ObservableCollection<OperationAccessRights>(Enum.GetValues(typeof(OperationAccessRights))
                                                                                         .Cast<OperationAccessRights>());
        }

        public void AddNewEmployee()
        {
            var newBee = new Employee(NewEmployeeName, NewEmployeeSurname, NewEmplAccessRight, someBank);
            Employees.Add(newBee);
            someBank.EmployWorker(newBee);
        }
    }
}
