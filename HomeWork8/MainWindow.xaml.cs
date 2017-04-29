using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankSystemViewModel bsViewModel;

        public MainWindow()
        {
            InitializeComponent();

            bsViewModel = new BankSystemViewModel();
            DataContext = bsViewModel;

            CommandBinding addNewEmployeeCommBind = new CommandBinding(Commands.AddNewEmployee,
                                                                       bsViewModel.ExecutedAddNewEmployee);
            CommandBindings.Add(addNewEmployeeCommBind);
            CommandBindings.Add(new CommandBinding(Commands.ServiceClient, bsViewModel.ExecutedServiceClient));
        }
    }
}
