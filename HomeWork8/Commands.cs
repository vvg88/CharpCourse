using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork8
{
    public static class Commands
    {
        public static RoutedCommand AddNewEmployee { get; }

        static Commands()
        {
            AddNewEmployee = new RoutedCommand("AddNewEmployee", typeof(Commands));
        }
    }
}
