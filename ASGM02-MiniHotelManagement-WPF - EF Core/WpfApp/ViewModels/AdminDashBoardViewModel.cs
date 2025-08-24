using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class AdminDashBoardViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        private object? _currentView;
        private string _welcomeMessage;

        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value; OnPropertyChanged();
            }
        }

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value; OnPropertyChanged();
            }
        }
        public ICommand NavigateCommand { get; }
        public AdminDashBoardViewModel(IServiceProvider serviceProvider)
        {
            WelcomeMessage = "Chào mừng Admin";
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            NavigateCommand = new RelayCommand(NavigateToPage);
            
            CurrentView = _serviceProvider.GetRequiredService<CustomerManagementView>();
        }
        private void NavigateToPage(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Customer":
                    CurrentView = _serviceProvider.GetRequiredService<CustomerManagementView>();
                    break;
                case "Room":
                    CurrentView = _serviceProvider.GetRequiredService<RoomManagementView>();
                    break;
                case "Booking":
                    CurrentView = _serviceProvider.GetRequiredService<BookingReservationManagementView>();
                    break;
                case "Report":
                    CurrentView = _serviceProvider.GetRequiredService<ReportManagementView>();
                    break;
                case "Logout":
                    LoginWindow loginWindow = new();
                    loginWindow.Show();
                    foreach (var window in System.Windows.Application.Current.Windows)
                    {
                        if (window is AdminDashBoardWindow)
                        {
                            ((AdminDashBoardWindow)window).Close();
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
