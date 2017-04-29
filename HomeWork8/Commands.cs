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

        public static RoutedCommand ServiceClient { get; }

        static Commands()
        {
            AddNewEmployee = new RoutedCommand("AddNewEmployee", typeof(Commands));
            ServiceClient = new RoutedCommand("ServiceClient", typeof(Commands));
        }
    }
}
