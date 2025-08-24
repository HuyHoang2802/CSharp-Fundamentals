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
using Repository.DTO;
using Service.UserService;

namespace PRN212_Assignment_01
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        CutomerService cutomerService;
        public HomeWindow(CustomerDTO value)
        {
            InitializeComponent();
             cutomerService = new CutomerService();
            dgCustomers.ItemsSource = cutomerService.ViewCustomer();
            txtWelcome.Text = "Hi," + value.CustomerFullName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Hide();

        }



        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (CustomerDTO)dgCustomers.SelectedItem;
            if (selected != null)
            {
                txtCustomerId.Text = selected.CustomerId.ToString();
                txtCustomerName.Text = selected.CustomerFullName ?? string.Empty;
                txtCustomerEmail.Text = selected.EmailAddress.ToString();
                txtCustomerPhone.Text = selected.Telephone ?? string.Empty;
                dpDOB.SelectedDate = selected.CustomerBirthday;
                txtCustomerstatus.Text = selected.CustomerStatus.ToString();
            }

        }

        private void LoadData()
        {
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = cutomerService.ViewCustomer();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var name = txtSearchCustomerName.Text;
            var id = txtSearchCustomerId.Text != null ? txtSearchCustomerId.Text : "";
            cutomerService = new();
            try
            {
                dgCustomers.ItemsSource = null;
                if (id != null)
                {
                    dgCustomers.ItemsSource = cutomerService.SearchCustomer(name, int.Parse(id));

                }
                else
                {
                    dgCustomers.ItemsSource = cutomerService.SearchCustomer(name, -1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var customer = (CustomerDTO)dgCustomers.SelectedItem;
            bool check = cutomerService.RemoveCutomer(customer.CustomerId);
            if (check == true)
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Error to remve", "Error ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomerDTO cus = new();
            cus.CustomerFullName = txtCustomerName.Text;
            cus.Telephone = txtCustomerPhone.Text;
            cus.CustomerBirthday = dpDOB.SelectedDate.Value;
            cus.EmailAddress = txtCustomerEmail.Text;
            cus.CustomerStatus = byte.Parse(txtCustomerstatus.Text);


            cutomerService.AddCutomer(cus);
            LoadData();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CustomerDTO cus = new();
            cus.CustomerFullName = txtCustomerName.Text;
            cus.Telephone = txtCustomerPhone.Text;
            cus.CustomerBirthday = dpDOB.SelectedDate.Value;
            cus.EmailAddress = txtCustomerEmail.Text;
            cus.CustomerStatus = byte.Parse(txtCustomerstatus.Text);


            cutomerService.UpdateCutomer(cus);
            LoadData();
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
             this.Close();
        }

    }
}
