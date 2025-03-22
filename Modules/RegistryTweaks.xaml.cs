using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Windows_Config_Toolkit.Modules
{
    public partial class RegistryTweaks : UserControl
    {
        public RegistryTweaks()
        {
            InitializeComponent();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (chkDisableCortana.IsChecked == true)
                SetRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0);

            if (chkClassicTaskbar.IsChecked == true)
                SetRegistryValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel", 2);

            if (chkRemoveOneDrive.IsChecked == true)
                SetRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\OneDrive", "DisableFileSyncNGSC", 1);

            if (chkDisableLockScreen.IsChecked == true)
                SetRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization", "NoLockScreen", 1);

            MessageBox.Show("Tweaks applied successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            chkDisableCortana.IsChecked = false;
            chkClassicTaskbar.IsChecked = false;
            chkRemoveOneDrive.IsChecked = false;
            chkDisableLockScreen.IsChecked = false;
        }

        private void SetRegistryValue(string path, string key, object value)
        {
            try
            {
                // Note: Must match the correct root key
                if (path.StartsWith(@"HKEY_LOCAL_MACHINE"))
                    Registry.SetValue(path, key, value, RegistryValueKind.DWord);
                else if (path.StartsWith(@"HKEY_CURRENT_USER"))
                    Registry.SetValue(path, key, value, RegistryValueKind.DWord);
            }
            catch
            {
                MessageBox.Show($"Error writing to: {path}\\{key}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
