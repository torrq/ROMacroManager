using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace ROMacroManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if running as administrator
            if (!IsRunningAsAdministrator())
            {
                // Restart the application with admin privileges
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };

                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"This application requires administrator privileges to modify registry settings.\n\nError: {ex.Message}",
                        "Administrator Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Add reference to Microsoft.VisualBasic for InputBox
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsRunningAsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}