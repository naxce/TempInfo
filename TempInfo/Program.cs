using System;
using System.Windows.Forms;

namespace TempInfo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                ShowDebugInfo(e.ExceptionObject as Exception);

            Application.ThreadException += (sender, e) =>
                ShowDebugInfo(e.Exception);

            try
            {
                Application.Run(new FormStart());
            }
            catch (Exception ex)
            {
                ShowDebugInfo(ex);
            }
        }

        private static void ShowDebugInfo(Exception? ex)
        {
            if (ex == null) return;

            string errorMessage = $"CRITICAL ERROR:\n\n" +
                                 $"Message: {ex.Message}\n\n" +
                                 $"Source: {ex.Source}\n\n" +
                                 $"Stack Trace:\n{ex.StackTrace}\n\n" +
                                 $"Target Site: {ex.TargetSite}";

            MessageBox.Show(errorMessage, "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}