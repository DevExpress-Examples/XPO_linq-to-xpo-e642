using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace XpoLinqNorthwindSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionStr = MSSqlConnectionProvider.GetConnectionString("(local)", "Northwind");
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionStr, AutoCreateOption.DatabaseAndSchema);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
