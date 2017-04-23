using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Bank
    {
        private List<Account> accounts = new List<Account> { };
        public IList<Account> Accounts
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

        public bool ProvideService(Operation requiredOperation, out string outMessage)
        {
            if (IsOpen)
            {
                Employee employee = GetFreeEmployee(requiredOperation);
                
                if (employee == null)
                {
                    outMessage = "Все сотрудники в данный момент заняты!";
                    return false;
                }
                return employee.ProvideService(requiredOperation, out outMessage);
            }
            else
            {
                outMessage = "Банк закрыт!";
                return false;
            }
        }

        private Employee GetFreeEmployee(Operation requiredOp)
        {
            return employees.FirstOrDefault(staff => staff.CheckAccessibility(requiredOp));
        }

        public void EmployWorker(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }
    }
}
