using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Windows_Config_Toolkit.Modules
{
    public partial class StartupManager : UserControl
    {
        public class StartupItem
        {
            public string Name { get; set; } = "";
            public string Path { get; set; } = "";
        }

        private readonly ObservableCollection<StartupItem> _startupItems = new();

        public StartupManager()
        {
            InitializeComponent();
            LoadStartupItems();
        }

        private void LoadStartupItems()
        {
            _startupItems.Clear();
            string registryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(registryPath);

            if (key != null)
            {
                foreach (var name in key.GetValueNames())
                {
                    var path = key.GetValue(name)?.ToString() ?? "";
                    _startupItems.Add(new StartupItem { Name = name, Path = path });
                }
            }

            StartupList.ItemsSource = _startupItems;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadStartupItems();
        }

        private void BtnDisableSelected_Click(object sender, RoutedEventArgs e)
        {
            if (StartupList.SelectedItem is StartupItem selected)
            {
                try
                {
                    string registryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
                    using RegistryKey? key = Registry.CurrentUser.OpenSubKey(registryPath, writable: true);

                    if (key != null)
                    {
                        key.DeleteValue(selected.Name, false);
                        MessageBox.Show($"Removed '{selected.Name}' from Startup.", "Success");
                        LoadStartupItems();
                    }
                    else
                    {
                        MessageBox.Show("Could not access the registry key.", "Warning");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select an item to disable.", "Info");
            }
        }

    }
}
