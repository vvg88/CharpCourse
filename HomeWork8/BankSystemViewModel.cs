using BankSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

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

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("clients.xml");
        }

        public void AddNewEmployee()
        {
            var newBee = new Employee(NewEmployeeName, NewEmployeeSurname, NewEmplAccessRight, someBank);
            Employees.Add(newBee);
            someBank.EmployWorker(newBee);
        }
    }
}
