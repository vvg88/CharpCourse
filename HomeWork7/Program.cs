using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank yourFinance = new Bank();

            yourFinance.EmployWorker(new Employee("Стукачев", "Станислав", OperationAccessRights.AddWithdraw, yourFinance));
            yourFinance.EmployWorker(new Employee("Куклачев", "Юрий", OperationAccessRights.AddWithdraw, yourFinance));
            yourFinance.EmployWorker(new Employee("Пугачев", "Виталий", OperationAccessRights.AddWithdrawCreateRemove, yourFinance));
            yourFinance.EmployWorker(new Employee("Калачев", "Сигизмунд", OperationAccessRights.AddWithdrawCreateRemove, yourFinance));
            yourFinance.EmployWorker(new Employee("Деревянкин", "Денис", OperationAccessRights.AddWithdrawCreateRemove, yourFinance));

            List<Client> clients = new List<Client>
            {
                new Client("Иванов", "Иван") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 1000) },
                new Client("Петров", "Петр") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 5000) },
                new Client("Сидоров", "Авраам") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 3000) },
                new Client("Иванова", "Алла") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 6000) },
                new Client("Петрова", "Мария") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 10000) },
            };

            Action<Client> showService = (client) =>
            {
                string outMessage = string.Empty;
                bool serviceResult = false;
                serviceResult = yourFinance.ProvideService(client, out outMessage);
                Console.WriteLine($"Клиент {client.Surname} {client.Name} {(serviceResult ? "обслужен" : "не обслужен")}\n" + outMessage);
            };

            // Продемонстрировать закрытый банк
            Bank.CurrentTime = DateTime.Today;
            showService(clients[0]);
            Console.WriteLine();

            // Продемонстрировать занятых сотрудников
            Bank.CurrentTime = Bank.CurrentTime.AddHours(9);
            foreach (var client in clients)
            {
                showService(client);
            }
            Console.WriteLine();

            // Сотрудники должны освободиться
            Thread.Sleep(1500);
            showService(clients[3]);
            showService(clients[4]);
            Console.WriteLine();

            // Продемонстрировать прочие операции со счетами
            clients[0].RequiredOperation = new Operation(yourFinance.GetClientAccounts(clients[0]).ElementAt(0), OperationType.AddMoney, 500);
            showService(clients[0]);
            Console.WriteLine();

            clients[1].RequiredOperation = new Operation(yourFinance.GetClientAccounts(clients[1]).ElementAt(0), OperationType.WithdrawMoney, 500);
            showService(clients[1]);
            Console.WriteLine();

            clients[2].RequiredOperation = new Operation(null, OperationType.CreateAccount, 500);
            showService(clients[2]);
            Console.WriteLine();

            clients[3].RequiredOperation = new Operation(yourFinance.GetClientAccounts(clients[3]).ElementAt(0), OperationType.CreateAccount, 5000);
            showService(clients[3]);
            Console.WriteLine();

            clients[4].RequiredOperation = new Operation(yourFinance.GetClientAccounts(clients[4]).ElementAt(0), OperationType.Nothing, 500);
            showService(clients[4]);
            Console.WriteLine();

            Console.Read();
        }
    }
}
