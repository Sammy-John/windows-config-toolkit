using System;
using System.Collections.ObjectModel;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Controls;

namespace Windows_Config_Toolkit.Modules
{
    public partial class ServicesManager : UserControl
    {
        public class ServiceItem
        {
            public string ServiceName { get; set; } = "";
            public string Status { get; set; } = "";
            public string StartType { get; set; } = "";
            public ServiceController Controller { get; set; } = new ServiceController();
        }

        private readonly ObservableCollection<ServiceItem> _services = new();

        public ServicesManager()
        {
            InitializeComponent();

            // SAFER: Load after full control rendering
            this.Loaded += ServicesManager_Loaded;
        }

        private void ServicesManager_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadServices();
            }
            catch (PlatformNotSupportedException)
            {
                MessageBox.Show("This platform does not support service control APIs.", "Unsupported Platform", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load services.\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadServices()
        {
            _services.Clear();

            try
            {
                foreach (var service in ServiceController.GetServices())
                {
                    _services.Add(new ServiceItem
                    {
                        ServiceName = service.DisplayName,
                        Status = service.Status.ToString(),
                        StartType = "Manual", // Placeholder - future enhancement
                        Controller = service
                    });
                }

                ServicesList.ItemsSource = _services;
            }
            catch (PlatformNotSupportedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadServices();
        }

        private void BtnStartService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesList.SelectedItem is ServiceItem selected)
            {
                try
                {
                    selected.Controller.Start();
                    selected.Controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                    LoadServices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to start service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a service to start.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnStopService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesList.SelectedItem is ServiceItem selected)
            {
                try
                {
                    selected.Controller.Stop();
                    selected.Controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                    LoadServices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to stop service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a service to stop.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
