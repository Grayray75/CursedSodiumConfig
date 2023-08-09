using System;
using System.IO;
using System.Windows.Forms;
using CursedSodiumConfig.WinForms.Config;

namespace CursedSodiumConfig.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Parameter 'config path' is missing!");
                Console.WriteLine("Using fallback ./sodium-config.json");
            }
            else
            {
                string configPath = Path.GetFullPath(args[0]);
                VideoConfigIO.ConfigPath = configPath;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}
