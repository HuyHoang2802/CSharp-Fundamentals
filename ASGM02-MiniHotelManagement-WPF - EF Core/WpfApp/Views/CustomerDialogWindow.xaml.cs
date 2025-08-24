using BusinessObject;
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
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for CustomerDialogWindow.xaml
    /// </summary>
    public partial class CustomerDialogWindow : Window
    {
        public CustomerDialogWindow(Customer customer, bool isNew)
        {
            InitializeComponent();
            DataContext = new CustomerViewModel(customer, isNew, this);
        }
    }
}
