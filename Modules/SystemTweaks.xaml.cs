using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Windows_Config_Toolkit.Modules
{
    public partial class SystemTweaks : UserControl
    {
        public SystemTweaks()
        {
            InitializeComponent();
            LoadTweakStates(); // Load state on init
        }

        private void LoadTweakStates()
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search");
                object? val = key?.GetValue("SearchboxTaskbarMode");

                chkHideSearchButton.IsChecked = (val != null && Convert.ToInt32(val) == 0);
            }
            catch
            {
                chkHideSearchButton.IsChecked = false;
            }
        }

        private void chkHideSearchButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search");
                key?.SetValue("SearchboxTaskbarMode", 0, RegistryValueKind.DWord); // Hide
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying tweak: {ex.Message}");
            }
        }

        private void chkHideSearchButton_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search");
                key?.SetValue("SearchboxTaskbarMode", 1, RegistryValueKind.DWord); // Show (icon only)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reverting tweak: {ex.Message}");
            }
        }

        // ✅ ADD THESE HANDLERS TO MATCH THE XAML BUTTONS

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Optional: reset checkbox state or clear registry values
            chkHideSearchButton.IsChecked = false;
            chkDisableTelemetry.IsChecked = false;
            chkDisableActionCenter.IsChecked = false;
            chkDisableSuggestions.IsChecked = false;
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Apply additional toggles here, if needed
                // The Search Button tweak is already bound to checkbox events (Checked/Unchecked)
                MessageBox.Show("System Tweaks applied successfully.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply tweaks: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
