using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Client : Person
    {
        public Operation RequiredOperation { get; set; } = new Operation(null, OperationType.Nothing, 0);

        public Client(string name, string surname) : base(name, surname)
        { }
    }
}
