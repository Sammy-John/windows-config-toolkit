using System;
using System.Windows;
using System.Windows.Controls;
using Windows_Config_Toolkit.Modules;

namespace Windows_Config_Toolkit
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadModule("RegistryTweaks");
            LoadModule("ServicesManager");
            LoadModule("StartupManager");
            LoadModule("SystemTweaks");
        }

        // 🔸 Central Module Loader
        private void LoadModule(string moduleName)
        {
            UserControl module;
            switch (moduleName)
            {
                case "RegistryTweaks":
                    module = new RegistryTweaks();
                    break;
                case "StartupManager":
                    module = new StartupManager();
                    break;
                case "ServicesManager":
                    module = new ServicesManager();
                    break;
                case "SystemTweaks":
                    module = new SystemTweaks();
                    break;
                case "SystemRestore":
                    module = new SystemRestore();
                    break;
                case "CommandRunner":
                    module = new CommandRunner();
                    break;

                default:
                    module = new UserControl
                    {
                        Content = new TextBlock
                        {
                            Text = $"Module '{moduleName}' not found.",
                            FontSize = 16,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        }
                    };
                    break;
            }

            MainContent.Content = module;
        }

        // 🔹 Sidebar Button Handlers
        private void BtnRegistryTweaks_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("RegistryTweaks");
        }

        private void BtnStartupManager_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("StartupManager");
        }

        private void BtnServicesManager_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("ServicesManager");
        }
        private void BtnSystemTweaks_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("SystemTweaks");
        }
        private void BtnSystemRestore_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("SystemRestore");
        }

        private void BtnCommandRunner_Click(object sender, RoutedEventArgs e)
        {
            LoadModule("CommandRunner");
        }

    }
}
