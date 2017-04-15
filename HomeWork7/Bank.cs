using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Bank
    {
        private List<Account> accounts = new List<Account> { };
        public IReadOnlyList<Account> Accounts
        {
            get { return accounts; }
        }

        private List<Employee> employees = new List<Employee> { };
        public IReadOnlyList<Employee> Employees
        {
            get { return employees; }
        }

        public bool IsOpen
        {
            get { return CurrentTime.Hour >= 8 && CurrentTime.Hour < 20; }
        }

        public static DateTime CurrentTime { get; set; }

        public bool ProvideService(Client client, out string outMessage)
        {
            if (IsOpen)
            {
                if (client.RequiredOperation.OperationType == OperationType.Nothing)
                {
                    outMessage = "Клиенту ничего не нужно.";
                    return false;
                }
                Employee employee;
                if (client.RequiredOperation.OperationType == OperationType.CreateAccount || client.RequiredOperation.OperationType == OperationType.RemoveAccount)
                    employee = employees.FirstOrDefault(staff => staff.AccessRight == OperationAccessRights.AddWithdrawCreateRemove && !staff.IsBusy);
                else
                    employee = employees.FirstOrDefault(staff => !staff.IsBusy);
                
                if (employee == null)
                {
                    outMessage = "Все сотрудники в данный момент заняты!";
                    return false;
                }
                return employee.ProvideService(client, out outMessage);
            }
            else
            {
                outMessage = "Банк закрыт!";
                return false;
            }
        }

        public void EmployWorker(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }

        public IEnumerable<Account> GetClientAccounts(Client client) => from acc in accounts
                                                                        where acc.Owner == client
                                                                        select acc;
    }
}
