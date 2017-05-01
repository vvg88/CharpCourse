using Pharmacy.BusinessLogic;
using System.Windows;

namespace Pharmacy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new PharmacyViewModel();
        }
    }
}
