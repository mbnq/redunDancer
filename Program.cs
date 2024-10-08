using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Diagnostics;

namespace redunDancer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!IsAdministrator())
            {
                // Restart the application with admin rights
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    Process.Start(proc);
                }
                catch
                {
                    // The user refused the elevation
                    MessageBox.Show("This application requires administrator privileges to run.");
                }
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mbForm1());
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
