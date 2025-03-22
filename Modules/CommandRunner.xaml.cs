using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Windows_Config_Toolkit.Modules
{
    public partial class CommandRunner : UserControl
    {
        public CommandRunner()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Scripts (*.ps1;*.cmd;*.bat)|*.ps1;*.cmd;*.bat|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == true)
            {
                txtCommandPath.Text = dialog.FileName;
            }
        }

        private void BtnRunCommand_Click(object sender, RoutedEventArgs e)
        {
            string path = txtCommandPath.Text.Trim();

            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                MessageBox.Show("Invalid script path.");
                return;
            }

            string ext = Path.GetExtension(path).ToLower();
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();

                if (ext == ".ps1")
                {
                    psi.FileName = "powershell.exe";
                    psi.Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{path}\"";
                }
                else if (ext == ".bat" || ext == ".cmd")
                {
                    psi.FileName = "cmd.exe";
                    psi.Arguments = $"/c \"{path}\"";
                }
                else
                {
                    MessageBox.Show("Unsupported file type.");
                    return;
                }

                psi.Verb = "runas";
                psi.UseShellExecute = true;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to execute: {ex.Message}");
            }
        }
    }
}
