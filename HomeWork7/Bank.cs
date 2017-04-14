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
                if (client.RequiredOperation.OperationType == OperationType.AddMoney || client.RequiredOperation.OperationType == OperationType.WithdrawMoney)
                {
                    var employee = employees.FirstOrDefault(staff => staff.AccessRight == OperationAccessRights.AddWithdraw && !staff.IsBusy);
                    if (employee == null)
                    {
                        outMessage = "Все сотрудники в данный момент заняты!";
                        return false;
                    }
                    return employee.ProvideService(client, out outMessage);
                }
                else
                {

                }
            }
            else
            {
                outMessage = "Банк закрыт!";
                return false;
            }
            throw new NotImplementedException();
        }
    }

    enum OperationType { Nothing, AddMoney, WithdrawMoney, CreateAccount, RemoveAccount }

    enum OperationAccessRights { AddWithdraw, AddWithdrawCreateRemove }
}
