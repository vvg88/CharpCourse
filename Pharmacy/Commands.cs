using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pharmacy
{
    public static class Commands
    {
        public static RoutedCommand FilteredNameChanged { get; }

        public static RoutedCommand FilteredSymptomChanged { get; }

        static Commands()
        {
            FilteredNameChanged = new RoutedCommand("FilteredNameChanged", typeof(Commands));
            FilteredSymptomChanged = new RoutedCommand("FilteredSymptomChanged", typeof(Commands));
        }
    }
}
