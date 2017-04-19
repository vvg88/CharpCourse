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

namespace HomeWork8
{
    class BankSystemViewModel : INotifyPropertyChanged
    {
        private Bank someBank;

        public ObservableCollection<Employee> Employees { get; }
        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();

        public ObservableCollection<OperationAccessRights> AccountOperationRights { get; }
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
        public OperationAccessRights NewEmplAccessRight { get; set; }
        public OperationType CurrentOperationType { get; set; }
        public Account SelectedAccount { get; set; }

        private string serviceMessages;

        public event PropertyChangedEventHandler PropertyChanged;

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
                var clientAccounts = someBank.GetClientAccounts(selectedClient);
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


        public BankSystemViewModel()
        {
            someBank = new Bank();
            someBank.EmployWorker(new Employee("Иван", "Иванов", OperationAccessRights.AddWithdraw, someBank));
            someBank.EmployWorker(new Employee("Петр", "Петров", OperationAccessRights.AddWithdraw, someBank));
            someBank.EmployWorker(new Employee("Алексей", "Алексеев", OperationAccessRights.AddWithdrawCreateRemove, someBank));
            Employees = new ObservableCollection<Employee>(someBank.Employees);

            AccountOperationRights = new ObservableCollection<OperationAccessRights>(Enum.GetValues(typeof(OperationAccessRights))
                                                                                         .Cast<OperationAccessRights>());
            OperationTypes = Enum.GetValues(typeof(OperationType)).Cast<OperationType>().ToArray();

            if (!File.Exists("clients.xml"))
            {
                List<Client> clients = new List<Client>
                {
                    new Client("Иван", "Иванов") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 1000) },
                    new Client("Петр", "Петров") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 5000) },
                    new Client("Авраам", "Сидоров") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 3000) },
                    new Client("Алла", "Иванова") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 6000) },
                    new Client("Мария", "Петрова") { RequiredOperation = new Operation(null, OperationType.CreateAccount, 10000) },
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
                Clients.Add(new Client(clientNode.Attributes["Name"].InnerText, clientNode.Attributes["Surname"].InnerText)
                                      { RequiredOperation = new OperationWithAccount(null, OperationType.Nothing, 0) });
            }
            Bank.CurrentTime = Bank.CurrentTime.AddHours(9);
        }

        public void AddNewEmployee()
        {
            var newBee = new Employee(NewEmployeeName, NewEmployeeSurname, NewEmplAccessRight, someBank);
            Employees.Add(newBee);
            someBank.EmployWorker(newBee);
        }

        public void ServiceClient()
        {
            var serviceMsg = string.Empty;
            if (SelectedClient != null)
            {
                SelectedClient.RequiredOperation = new Operation(SelectedAccount, CurrentOperationType, SelectedClient.RequiredOperation.MoneyAmount);
                string srvMsg;
                var serviceResult = someBank.ProvideService(SelectedClient, out srvMsg);
                serviceMsg = $"Клиент {SelectedClient.Surname} {SelectedClient.Name} {(serviceResult ? "обслужен" : "не обслужен")}\n" + srvMsg;
            }
            ServiceMessages = serviceMsg;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
