using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank yourFinance = new Bank();

            yourFinance.EmployWorker(new Employee("Стукачев", "Станислав", OperationType.Nothing, yourFinance));
            yourFinance.EmployWorker(new Employee("Куклачев", "Юрий", OperationType.AddMoney | OperationType.WithdrawMoney, yourFinance));
            yourFinance.EmployWorker(new Employee("Пугачев", "Виталий", OperationType.AddMoney | OperationType.WithdrawMoney, yourFinance));
            yourFinance.EmployWorker(new Employee("Калачев", "Сигизмунд", OperationType.AddMoney | OperationType.WithdrawMoney | OperationType.CreateAccount, yourFinance));
            yourFinance.EmployWorker(new Employee("Деревянкин", "Денис", OperationType.AddMoney | OperationType.WithdrawMoney | OperationType.CreateAccount | OperationType.RemoveAccount, yourFinance));

            List<Client> clients = new List<Client>
            {
                new Client("Иван", "Иванов", yourFinance),
                new Client("Петр", "Петров", yourFinance),
                new Client("Авраам", "Сидоров", yourFinance),
                new Client("Алла", "Иванова", yourFinance),
                new Client("Мария", "Петрова", yourFinance),
            };

            Action<Client, Operation> showService = (client, operation) =>
            {
                string outMessage = string.Empty;
                bool serviceResult = false;
                serviceResult = yourFinance.ProvideService(operation, out outMessage);
                Console.WriteLine($"Клиент {client.Surname} {client.Name} {(serviceResult ? "обслужен" : "не обслужен")}\n" + outMessage);
            };

            // Продемонстрировать закрытый банк
            Operation reqOper = new CreateAccountOperation(new Account(0, clients[0]));
            Bank.CurrentTime = DateTime.Today;
            showService(clients[0], reqOper);
            Console.WriteLine();

            // Продемонстрировать занятых сотрудников
            Bank.CurrentTime = Bank.CurrentTime.AddHours(9);
            foreach (var client in clients)
            {
                showService(client, new CreateAccountOperation(new Account(0, client)));
            }
            Console.WriteLine();

            // Сотрудники должны освободиться
            Thread.Sleep(1100);
            showService(clients[2], new CreateAccountOperation(new Account(0, clients[2])));
            showService(clients[3], new CreateAccountOperation(new Account(0, clients[3])));
            Thread.Sleep(1100);
            showService(clients[4], new CreateAccountOperation(new Account(0, clients[4])));
            Console.WriteLine();

            // Продемонстрировать прочие операции со счетами
            reqOper = new AddMoneyOperation(clients[0].Accounts.ElementAt(0), 500);
            showService(clients[0], reqOper);
            Console.WriteLine();

            reqOper = new WithdrawMoneyOperation(clients[1].Accounts.ElementAt(0), 500);
            showService(clients[1], reqOper);
            Console.WriteLine();

            reqOper = new CreateAccountOperation(new Account(1000, clients[2]));
            showService(clients[2], reqOper);
            Console.WriteLine();

            Thread.Sleep(1100);
            reqOper = new RemoveAccountOperation(clients[3].Accounts.ElementAt(0));
            showService(clients[3], reqOper);
            Console.WriteLine();

            Console.Read();
        }
    }
}
