using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp.Views;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IConfiguration>(context.Configuration);

                    //các Services
                    services.AddSingleton<ICustomerService, CustomerService>();
                    services.AddSingleton<IRoomInformationService, RoomInfomationService>();
                    services.AddSingleton<IRoomTypeService, RoomTypeService>();
                    services.AddSingleton<IBookingReservationService, BookingReservationService>();
                    services.AddSingleton<IBookingDetailService, BookingDetailService>();

                    //các ViewModel
                    services.AddTransient<LoginViewModel>();
                    services.AddTransient<AdminDashBoardViewModel>();
                    services.AddTransient<CustomerManagementViewModel>();
                    services.AddTransient<RoomInformationManagementViewModel>();
                    services.AddTransient<BookingReservationManagementViewModel>();
                    services.AddTransient<ReportManagementViewModel>();
                    services.AddTransient<CustomerDashBoardViewModel>();
                    services.AddTransient<HistoryBookingViewModel>();

                    //các View
                    services.AddTransient<LoginWindow>();
                    services.AddTransient<AdminDashBoardWindow>();
                    services.AddTransient<CustomerDashBoardWindow>();
                    services.AddTransient<CustomerManagementView>();
                    services.AddTransient<RoomManagementView>();
                    services.AddTransient<BookingReservationManagementView>();
                    services.AddTransient<ReportManagementView>();
                    services.AddTransient<HistoryBookingView>();
                })
                .Build();
        }

        public static string GetAdminEmail()
        {
            var configuration = AppHost?.Services.GetRequiredService<IConfiguration>();
            return configuration?["AdminAccount:Email"] ?? String.Empty;
        }

        public static string GetAdminPassword()
        {
            var configuration = AppHost?.Services.GetRequiredService<IConfiguration>();
            return configuration?["AdminAccount:Password"] ?? String.Empty;
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var loginWindow = AppHost.Services.GetRequiredService<LoginWindow>();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            AppHost.Dispose();
            base.OnExit(e);
        }
    }

}
