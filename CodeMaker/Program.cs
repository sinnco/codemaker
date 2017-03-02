using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace DMedia.CodeMaker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string dbType = ConfigurationManager.AppSettings["DBTYPE"].ToString().ToUpper();
            switch (dbType)
            {
                case "MSSQL":
                    MsSqlLogin sqlLogin = new MsSqlLogin();
                    if (sqlLogin.ShowDialog() == DialogResult.OK)
                    {
                        MainWindow main = new MainWindow(sqlLogin.conn);
                        main.WindowState = FormWindowState.Maximized;
                        Application.Run(main);
                    }
                    break;
                case "MYSQL":
                    MySqlLogin mysqlLogin = new MySqlLogin();
                    if (mysqlLogin.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new MainWindow(mysqlLogin.conn));
                    }
                    break;
                case "ORACLE":
                    OracleLogin oracleLogin = new OracleLogin();
                    if (oracleLogin.ShowDialog() == DialogResult.OK)
                    {
                        MainWindow main = new MainWindow(oracleLogin.conn);
                        main.WindowState = FormWindowState.Maximized;
                        Application.Run(main);
                    }
                    break;
            }

        }
    }
}
