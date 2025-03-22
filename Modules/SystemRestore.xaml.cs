using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Windows_Config_Toolkit.Modules
{
    public partial class SystemRestore : UserControl
    {
        public SystemRestore()
        {
            InitializeComponent();
        }

        private void BtnCreateRestore_Click(object sender, RoutedEventArgs e)
        {
            string name = txtRestoreName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a restore point name.");
                return;
            }

            string psCommand = $"Checkpoint-Computer -Description \"{name}\" -RestorePointType \"MODIFY_SETTINGS\"";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psCommand}\"",
                    Verb = "runas", // Prompt for admin
                    UseShellExecute = true
                };

                Process.Start(psi);
                MessageBox.Show("Restore point creation triggered (check System Protection).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed: {ex.Message}");
            }
        }
    }
}
