using BankSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Input;

namespace HomeWork8
{
    public class BankSystemViewModel : INotifyPropertyChanged
    {
        private Bank someBank;

        public ObservableCollection<Employee> Employees { get; }
        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();

        public ObservableCollection<AccessRightItem> AccountOperationRights { get; }
        private OperationType[] operationTypes;
        public OperationType[] OperationTypes
        {
            get { return operationTypes; }
            set
            {
                operationTypes = value;
                NotifyPropertyChanged();
            }
        }

        public string NewEmployeeName { get; set; }
        public string NewEmployeeSurname { get; set; }
        public OperationType NewEmplAccessRight { get; set; }
        public OperationType CurrentOperationType { get; set; }
        public Account SelectedAccount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string serviceMessages;
        public string ServiceMessages
        {
            get { return serviceMessages; }
            set
            {
                var sb = new StringBuilder(serviceMessages);
                sb.AppendLine(value);
                sb.AppendLine();
                serviceMessages = sb.ToString();
                NotifyPropertyChanged();
            }
        }

        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                var clientAccounts = selectedClient.Accounts;
                SelectedClientAccounts = clientAccounts?.ToArray();
            }
        }

        private Account[] selectedClientAccounts;

        public Account[] SelectedClientAccounts
        {
            get { return selectedClientAccounts; }
            set
            {
                selectedClientAccounts = value;
                NotifyPropertyChanged();
            }
        }

        public double MoneyAmount { get; set; }

        public BankSystemViewModel()
        {
            someBank = new Bank();
            someBank.EmployWorker(new Employee("Иван", "Иванов", OperationType.AddMoney | OperationType.WithdrawMoney, someBank));
            someBank.EmployWorker(new Employee("Петр", "Петров", OperationType.AddMoney | OperationType.WithdrawMoney | OperationType.CreateAccount, someBank));
            someBank.EmployWorker(new Employee("Алексей", "Алексеев", OperationType.AddMoney | OperationType.WithdrawMoney | OperationType.CreateAccount | OperationType.RemoveAccount, someBank));
            Employees = new ObservableCollection<Employee>(someBank.Employees);

            AccountOperationRights = new ObservableCollection<AccessRightItem>
            {
                new AccessRightItem(OperationType.AddMoney),
                new AccessRightItem(OperationType.WithdrawMoney),
                new AccessRightItem(OperationType.CreateAccount),
                new AccessRightItem(OperationType.RemoveAccount),
            };
            OperationTypes = Enum.GetValues(typeof(OperationType)).Cast<OperationType>().ToArray();

            if (!File.Exists("clients.xml"))
            {
                List<Client> clients = new List<Client>
                {
                    new Client("Иван", "Иванов", someBank),
                    new Client("Петр", "Петров", someBank),
                    new Client("Авраам", "Сидоров", someBank),
                    new Client("Алла", "Иванова", someBank),
                    new Client("Мария", "Петрова", someBank),
                };
                using (XmlWriter xmlWriter = XmlWriter.Create("clients.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Clients");
                    foreach (var client in clients)
                    {
                        xmlWriter.WriteStartElement("Client");
                        xmlWriter.WriteAttributeString(nameof(client.Name), client.Name);
                        xmlWriter.WriteAttributeString(nameof(client.Surname), client.Surname);
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("clients.xml");
            var xmlNodeClients = xmlDoc.ChildNodes[1];
            foreach (XmlNode clientNode in xmlNodeClients.ChildNodes)
            {
                Clients.Add(new Client(clientNode.Attributes["Name"].InnerText, clientNode.Attributes["Surname"].InnerText, someBank));
            }
            Bank.CurrentTime = Bank.CurrentTime.AddHours(9);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecutedAddNewEmployee(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewEmployeeName) || string.IsNullOrEmpty(NewEmployeeSurname))
            {
                MessageBox.Show("Введите данные сотрудника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var newBee = new Employee(NewEmployeeName, NewEmployeeSurname, AccessRightItem.OperationAccessRight, someBank);
            Employees.Add(newBee);
            someBank.EmployWorker(newBee);
        }

        public void ExecutedServiceClient(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Клиент не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (SelectedAccount == null && (CurrentOperationType != OperationType.CreateAccount))
            {
                MessageBox.Show("Счет не выбран!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var serviceMsg = string.Empty;
            Operation reqOper;
            switch (CurrentOperationType)
            {
                case OperationType.AddMoney:
                    reqOper = new AddMoneyOperation(SelectedAccount, MoneyAmount);
                    break;
                case OperationType.WithdrawMoney:
                    reqOper = new WithdrawMoneyOperation(SelectedAccount, MoneyAmount);
                    break;
                case OperationType.CreateAccount:
                    reqOper = new CreateAccountOperation(new Account(MoneyAmount, SelectedClient));
                    break;
                case OperationType.RemoveAccount:
                    reqOper = new RemoveAccountOperation(SelectedAccount);
                    break;
                default:
                    return;
            }
            string srvMsg;
            var serviceResult = someBank.ProvideService(reqOper, out srvMsg);
            serviceMsg = $"Клиент {SelectedClient.Surname} {SelectedClient.Name} {(serviceResult ? "обслужен" : "не обслужен")}\n" + srvMsg;
            ServiceMessages = serviceMsg;
        }
    }
}
