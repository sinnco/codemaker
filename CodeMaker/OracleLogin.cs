using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using DMedia.Common;
using DMedia.Utility;

namespace DMedia.CodeMaker
{
    public partial class OracleLogin : Form
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public Connection conn = new Connection();

        public OracleLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OracleLogin_Load(object sender, EventArgs e)
        {
            //加载数据库实例
            LoadDatabase();
            this.txb_Username.Text = ConfigurationManager.AppSettings["Username"] + "";
            this.txb_Password.Text = ConfigurationManager.AppSettings["Password"] + "";
            if (ConfigurationManager.AppSettings["Database"] != null)
            {
                string str = ConfigurationManager.AppSettings["Database"].ToString().Trim();
                for (int i = 0; i < this.cbb_Database.Items.Count; i++)
                {
                    if (this.cbb_Database.Items[i].ToString().Trim() == str)
                    {
                        this.cbb_Database.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            conn.DbType = "Oracle";
            conn.Alias = cbb_Database.Text;
            conn.Database = cbb_Database.Text;
            conn.Username = txb_Username.Text;
            conn.Password = txb_Password.Text;

            IAdoService adoService = new OracleService();
            string errorMessage = adoService.Test(conn);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            else
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                keyValues.Add("Database", this.conn.Database);
                keyValues.Add("Username", this.conn.Username);
                keyValues.Add("Password", this.conn.Password);
                Helper.SetAppSetting(keyValues);
                this.DialogResult = DialogResult.OK;
            }
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 加载所有数据库实例
        /// </summary>
        private void LoadDatabase()
        {
            string tnsConfigFileName = string.Format(ConfigurationManager.AppSettings["TNS"].ToString(), AppDomain.CurrentDomain.BaseDirectory);
            string configString = "";

            using (FileStream fileStream = new FileStream(tnsConfigFileName, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                configString = streamReader.ReadToEnd();
            }

            Regex regex = new Regex(@"\n(\w+\s)=", RegexOptions.Singleline);
            MatchCollection matches = regex.Matches(configString);
            foreach (Match item in matches)
            {
                cbb_Database.Items.Add(item.Groups[1].ToString());
            }
            if (cbb_Database.Items.Count > 0)
            {
                cbb_Database.SelectedIndex = 0;
            }
        }

    }
}
