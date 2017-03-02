namespace DMedia.CodeMaker
{
    partial class OracleLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.GboxConnection = new System.Windows.Forms.GroupBox();
            this.cbb_Database = new System.Windows.Forms.ComboBox();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.txb_Username = new System.Windows.Forms.TextBox();
            this.LbDb = new System.Windows.Forms.Label();
            this.LbDbPassword = new System.Windows.Forms.Label();
            this.LbDbUserName = new System.Windows.Forms.Label();
            this.GboxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(206, 200);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(107, 200);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "连 接";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // GboxConnection
            // 
            this.GboxConnection.Controls.Add(this.cbb_Database);
            this.GboxConnection.Controls.Add(this.txb_Password);
            this.GboxConnection.Controls.Add(this.txb_Username);
            this.GboxConnection.Controls.Add(this.LbDb);
            this.GboxConnection.Controls.Add(this.LbDbPassword);
            this.GboxConnection.Controls.Add(this.LbDbUserName);
            this.GboxConnection.Location = new System.Drawing.Point(12, 12);
            this.GboxConnection.Name = "GboxConnection";
            this.GboxConnection.Size = new System.Drawing.Size(368, 178);
            this.GboxConnection.TabIndex = 8;
            this.GboxConnection.TabStop = false;
            this.GboxConnection.Text = "建立连接";
            // 
            // cbb_Database
            // 
            this.cbb_Database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Database.FormattingEnabled = true;
            this.cbb_Database.Location = new System.Drawing.Point(105, 126);
            this.cbb_Database.Name = "cbb_Database";
            this.cbb_Database.Size = new System.Drawing.Size(174, 20);
            this.cbb_Database.TabIndex = 4;
            // 
            // txb_Password
            // 
            this.txb_Password.Location = new System.Drawing.Point(105, 87);
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.PasswordChar = '*';
            this.txb_Password.Size = new System.Drawing.Size(174, 21);
            this.txb_Password.TabIndex = 3;
            // 
            // txb_Username
            // 
            this.txb_Username.Location = new System.Drawing.Point(105, 43);
            this.txb_Username.Name = "txb_Username";
            this.txb_Username.Size = new System.Drawing.Size(174, 21);
            this.txb_Username.TabIndex = 2;
            // 
            // LbDb
            // 
            this.LbDb.AutoSize = true;
            this.LbDb.Location = new System.Drawing.Point(38, 129);
            this.LbDb.Name = "LbDb";
            this.LbDb.Size = new System.Drawing.Size(47, 12);
            this.LbDb.TabIndex = 4;
            this.LbDb.Text = "数据库:";
            // 
            // LbDbPassword
            // 
            this.LbDbPassword.AutoSize = true;
            this.LbDbPassword.Location = new System.Drawing.Point(38, 90);
            this.LbDbPassword.Name = "LbDbPassword";
            this.LbDbPassword.Size = new System.Drawing.Size(47, 12);
            this.LbDbPassword.TabIndex = 3;
            this.LbDbPassword.Text = "密  码:";
            // 
            // LbDbUserName
            // 
            this.LbDbUserName.AutoSize = true;
            this.LbDbUserName.Location = new System.Drawing.Point(38, 46);
            this.LbDbUserName.Name = "LbDbUserName";
            this.LbDbUserName.Size = new System.Drawing.Size(47, 12);
            this.LbDbUserName.TabIndex = 5;
            this.LbDbUserName.Text = "用户名:";
            // 
            // OracleLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 234);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.GboxConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OracleLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oracle登录";
            this.Load += new System.EventHandler(this.OracleLogin_Load);
            this.GboxConnection.ResumeLayout(false);
            this.GboxConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.GroupBox GboxConnection;
        private System.Windows.Forms.ComboBox cbb_Database;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.TextBox txb_Username;
        private System.Windows.Forms.Label LbDb;
        private System.Windows.Forms.Label LbDbPassword;
        private System.Windows.Forms.Label LbDbUserName;
    }
}