using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMedia.Utility;

namespace DMedia.CodeMaker
{
    public partial class MySqlLogin : Form
    {
        public Connection conn = new Connection();

        public MySqlLogin()
        {
            InitializeComponent();

            string tnsConfig = ConfigurationManager.AppSettings["TnsHost"].ToString();
            if (!string.IsNullOrWhiteSpace(tnsConfig))
            {
                this.txb_Server.Text = tnsConfig;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbb_Database.Text.Trim()))
            {
                MessageBox.Show("请选择数据库!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            conn.DbType = "MySql";
            conn.Alias = txb_Alias.Text;
            conn.Server = txb_Server.Text;
            conn.Port = "";
            conn.Database = cbb_Database.Text;
            conn.Username = txb_Username.Text;
            conn.Password = txb_Password.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            btn_Refresh.Enabled = false;
            try
            {
                string connectionString = string.Concat("Server=", txb_Server.Text, ";Database=information_schema", ";Uid=", txb_Username.Text, ";Pwd=", txb_Password.Text, ";");
                IAdoService adoService = new MySqlService();
                cbb_Database.DataSource = adoService.GetAllDatabase(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btn_Refresh.Enabled = true;
        }
    }
}
