using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DMedia.Common;
using DMedia.Utility;
using NVelocity;

namespace DMedia.CodeMaker
{
    public partial class MainWindow : Form
    {
        private Connection conn;
        private IList<Property> Properties = new List<Property>();
        private Table table;
        private string dbType;
        //服务
        private IAdoService adoService;

        public MainWindow(Connection connection)
        {
            InitializeComponent();
            this.conn = connection;
            this.dbType = connection.DbType;
            DataGrid_Columns.AutoGenerateColumns = false;
            DataGrid_Properties.AutoGenerateColumns = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            switch (dbType.ToUpper())
            {
                case "MSSQL":
                    adoService = new MsSqlService();
                    break;
                case "MYSQL":
                    adoService = new MySqlService();
                    break;
                case "ORACLE":
                    adoService = new OracleService();
                    break;
            }

            //加载表
            LoadTable();
            //模板
            LoadTemplate();
            //初始化属性
            InitProperty();
        }

        private void cbb_Tables_SelectedValueChanged(object sender, EventArgs e)
        {
            //填充表格
            table = adoService.GetTable(conn, Cmb_Tables.Text);
            if (table == null)
            { return; }
            DataGrid_Columns.DataSource = table.Columns;

            //生成映射文件
            CreatePropertyMapping(Cmb_Tables.Text);

            SetProperty(Cmb_Tables.Text, table.Columns);

            //显示、隐藏控件
            ShowContainer(1);

            //将所有的列选中
            foreach (DataGridViewRow item in DataGrid_Columns.Rows)
            {
                item.Cells[0].Value = 1;
            }
            Chk_CheckAll.Checked = true;
        }

        /// <summary>
        /// 获取所有的文件
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="files"></param>
        private void BindTag(TreeNode node, string path, List<string> files)
        {
            node.Tag = Path.Combine(path, node.Text);
            if (node.Nodes.Count == 0)
            {
                files.Add(node.Tag as string);
            }
            foreach (TreeNode node2 in node.Nodes)
            {
                this.BindTag(node2, node.Tag as string, files);
            }
        }

        /// <summary>
        /// 显示字段按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Column_Click(object sender, EventArgs e)
        {
            ShowContainer(1);
        }

        /// <summary>
        /// 代码预览按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Code_Click(object sender, EventArgs e)
        {
            Table parseTable = new Table();
            parseTable.Name = this.table.Name;
            parseTable.Database = this.table.Database;
            parseTable.Comments = this.table.Comments;
            foreach (DataGridViewRow row in DataGrid_Columns.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "1")
                {
                    ColumnSchema column = GetColumn(row.Cells["FieldName"].Value.ToString());
                    parseTable.Columns.Add(column);
                }
            }
            if (Tree_Template.SelectedNode == null || Tree_Template.SelectedNode.Text.IndexOf(".") < 0)
            {
                MessageBox.Show("请选择模板文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Helper helper = new Helper();
            CodeTemplate codeTemplate = new CodeTemplate(dbType);
            VelocityContext context = new VelocityContext();
            context.Put("Helper", helper);
            context.Put("Table", parseTable);
            context.Put("CurrentTime", DateTime.Now);
            foreach (DataGridViewRow row in DataGrid_Properties.Rows)
            {
                context.Put(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
            }
            try
            {
                RtbCode.Text = codeTemplate.ParseTemplate(context, GetNodePath(Tree_Template.SelectedNode));
            }
            catch (Exception ex)
            {
                RtbCode.Text = ex.Message;
            }

            ShowContainer(2);

        }

        /// <summary>
        /// 生成全部文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_File_Click(object sender, EventArgs e)
        {
            Table parseTable = new Table();
            parseTable.Name = this.table.Name;
            parseTable.Database = this.table.Database;
            parseTable.Comments = this.table.Comments;
            foreach (DataGridViewRow row in DataGrid_Columns.Rows)
            {
                if ((row.Cells[0].Value != null) && (row.Cells[0].Value.ToString() == "1"))
                {
                    ColumnSchema column = this.GetColumn(row.Cells["FieldName"].Value.ToString());
                    parseTable.Columns.Add(column);
                }
            }
            Helper helper = new Helper();
            CodeTemplate template = new CodeTemplate(this.dbType);
            VelocityContext context = new VelocityContext();
            context.Put("Helper", helper);
            context.Put("Table", parseTable);
            context.Put("CurrentTime", DateTime.Now);
            foreach (DataGridViewRow row in DataGrid_Properties.Rows)
            {
                context.Put(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
            }
            List<string> files = new List<string>();
            foreach (TreeNode node in Tree_Template.Nodes)
            {
                this.BindTag(node, "", files);
            }
            string fileName = "";
            string outDirInfo = string.Format(ConfigurationManager.AppSettings["Output"].ToString(), AppDomain.CurrentDomain.BaseDirectory);
            foreach (string tplFileName in files)
            {
                try
                {
                    fileName = Path.Combine(outDirInfo, tplFileName);
                    foreach (DataGridViewRow row in DataGrid_Properties.Rows)
                    {
                        fileName = fileName.Replace("${" + row.Cells[1].Value.ToString() + "}", row.Cells[2].Value.ToString());
                    }
                    this.CreateDirectory(fileName);
                    using (File.Create(fileName))
                    {
                    }
                    using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8")))
                    {
                        writer.Write(template.ParseTemplate(context, tplFileName));
                    }
                }
                catch (Exception exception)
                {
                    this.RtbCode.Text = exception.Message;
                }
            }
            this.RtbCode.SelectionStart = 0;
            this.RtbCode.ScrollToCaret();
            this.RtbCode.Text = "输出目录:  ";
            this.RtbCode.Text = this.RtbCode.Text + outDirInfo;
            this.RtbCode.Text = this.RtbCode.Text + "\r\n生成时间:  ";
            this.RtbCode.Text = this.RtbCode.Text + DateTime.Now.ToString();
            this.ShowContainer(2);
        }

        private void chk_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (DataGrid_Columns.Rows.Count > 0)
            {
                for (int i = 0; i < DataGrid_Columns.Rows.Count; i++)
                {
                    DataGrid_Columns.Rows[i].Cells[0].Value = Chk_CheckAll.Checked ? 1 : 0;
                }
            }
        }

        #region 私有方法
        /// <summary>
        /// 加载数据表
        /// </summary>
        private void LoadTable()
        {
            //表名称
            IList<Table> tables = adoService.GetTables(conn);
            foreach (Table item in tables)
            {
                Cmb_Tables.Items.Add(item.Name);
            }
            if (Cmb_Tables.Items.Count > 0)
            {
                Cmb_Tables.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 根据文件名创建目录
        /// </summary>
        /// <param name="fileName">文件</param>
        private void CreateDirectory(string fileName)
        {
            string path = fileName;
            if (fileName.IndexOf('\\') > 0)
            {
                path = fileName.Substring(0, fileName.LastIndexOf('\\'));
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 加载模板
        /// </summary>
        private void LoadTemplate()
        {
            string templatePath = Path.Combine(Application.StartupPath.ToString(), string.Concat("Templates\\", dbType));

            Tree_Template.Nodes.Clear();
            //TreeNode father = new TreeNode("模板", 4, 4);
            LoadAllFiles(templatePath, null, true, 7, 0);
            //tree_Template.Nodes.Add(father);
            Tree_Template.ExpandAll();
        }

        /// <summary>
        /// 显示容器
        /// </summary>
        /// <param name="index">1.字段 2.代码</param>
        private void ShowContainer(int index)
        {
            if (index == 1)
            {
                DataGrid_Columns.Show();
                RtbCode.Hide();
                Btn_Column.Enabled = false;
                Btn_Code.Enabled = true;
            }
            else
            {
                DataGrid_Columns.Hide();
                RtbCode.Show();
                Btn_Column.Enabled = true;
                Btn_Code.Enabled = true;
            }
        }

        /// <summary>
        /// 查找节点路径
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetNodePath(TreeNode node)
        {
            if (node.Parent == null || node.Parent.Text == "模板")
            {
                return node.Text;
            }
            return Path.Combine(GetNodePath(node.Parent), node.Text);
        }

        /// <summary>
        /// 获取列
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ColumnSchema GetColumn(string name)
        {
            foreach (ColumnSchema column in table.Columns)
            {
                if (column.Name == name)
                {
                    return column;
                }
            }

            return null;
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        private void InitProperty()
        {
            string tablePath = Path.Combine(Application.StartupPath.ToString(), "Config\\BaseProperty.xml");
            if (!File.Exists(tablePath))
            {
                return;
            }
            //加载配置
            XmlDocument doc = new XmlDocument();
            doc.Load(tablePath);
            Properties.Clear();
            //读取属性
            foreach (XmlNode node in doc.SelectNodes("property/add"))
            {
                Property property = new Property();
                property.Name = node.Attributes["name"].Value;
                property.Type = node.Attributes["type"].Value;
                property.Category = node.Attributes["category"].Value;
                property.Default = node.Attributes["default"].Value;
                property.Description = node.Attributes["description"].Value;
                property.Value = node.Attributes["default"].Value;
                Properties.Add(property);
            }
            DataGrid_Properties.DataSource = Properties;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        private void SetProperty(string tableName, IList<ColumnSchema> columns)
        {
            string tableNamePath = Path.Combine(Application.StartupPath.ToString(), string.Concat("Database\\", dbType, "\\", conn.Database, "\\", tableName, ".xml"));
            if (!File.Exists(tableNamePath))
            {
                return;
            }
            //加载配置
            XmlDocument doc = new XmlDocument();
            doc.Load(tableNamePath);
            //读取属性
            Dictionary<string, string> property = new Dictionary<string, string>();
            foreach (XmlNode node in doc.SelectNodes("columns/add"))
            {
                if (!property.ContainsKey(node.Attributes["name"].Value))
                {
                    property.Add(node.Attributes["name"].Value, node.Attributes["property"].Value);
                }
            }

            //设置属性
            foreach (ColumnSchema column in columns)
            {
                foreach (KeyValuePair<string, string> item in property)
                {
                    if (item.Key == column.Name)
                    {
                        column.Property = property[column.Name];
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 根据根据传递路径遍历该路径下的所有文件目录及文件
        /// </summary>
        /// <param name="path">目标路径</param>
        /// <param name="n">目标节点</param>
        /// <param name="showExt">显示后缀</param>
        /// <param name="p1">父节点图标</param>
        /// <param name="p2">子节点图标</param>
        private void LoadAllFiles(string path, TreeNode n, bool showExt, int p1, int p2)
        {
            //获取当前目录下的所有子目录
            string[] dir = Directory.GetDirectories(path);
            //获得当前目录下的所有文件
            string[] fil = Directory.GetFiles(path);
            //循环遍历文件
            foreach (string var in fil)
            {
                TreeNode node = null;
                string fileName = var.Substring(var.LastIndexOf('\\') + 1, var.Length - var.LastIndexOf('\\') - 1);
                if (showExt)
                {
                    node = new TreeNode(fileName, 1, 1);
                }
                else
                {
                    node = new TreeNode(fileName.Substring(0, fileName.IndexOf('.')), p1, p1);
                }
                //将该节点添加到目标节点下
                if (n == null)
                {
                    Tree_Template.Nodes.Add(node);
                }
                else
                {
                    n.Nodes.Add(node);
                }
            }
            //声明数组d用来存放文件目录
            string[] d;
            //声明数组f用来存放文件
            string[] f;
            //循环遍历文件目录
            foreach (string var in dir)
            {
                //用当前文件目录创建节点
                TreeNode node = new TreeNode(var.Substring(var.LastIndexOf('\\') + 1, var.Length - var.LastIndexOf('\\') - 1), p2, p2);
                //将该节点添加到目标节点下
                if (n == null)
                {
                    Tree_Template.Nodes.Add(node);
                }
                else
                {
                    n.Nodes.Add(node);
                }
                try
                {
                    //获取当前文件目录的文件目录
                    d = Directory.GetDirectories(var);
                    //获取当前文件目录下的文件
                    f = Directory.GetFiles(var);
                }
                catch (Exception)
                {
                    continue;
                }
                //判断该目录下是否还有文件及文件目录
                if (d.Length > 0 || f.Length > 0)
                {
                    //递归调用自身
                    //目录为当前目录
                    //节点为当前节点
                    LoadAllFiles(var, node, showExt, p1, p2);
                }
            }
        }

        /// <summary>
        /// 生成属性映射表
        /// </summary>
        /// <param name="tableName">表名</param>
        private void CreatePropertyMapping(string tableName)
        {
            string filePath = Path.Combine(Application.StartupPath.ToString(), string.Concat("Database\\", dbType, "\\", conn.Database, "\\", tableName, ".xml"));
            string dirPath = filePath.Substring(0, filePath.LastIndexOf("\\"));
            //每次都应该重建映射文件
            //如果映射文件存在，则退出。
            //if (File.Exists(filePath))
            //{
            //    return;
            //}
            //如果目录不存在，则创建。
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            //生成映射文件内容
            Table parseTable = new Table();
            foreach (DataGridViewRow row in DataGrid_Columns.Rows)
            {
                ColumnSchema column = GetColumn(row.Cells["FieldName"].Value.ToString());
                parseTable.Columns.Add(column);
            }
            Helper helper = new Helper();
            CodeTemplate codeTemplate = new CodeTemplate("Public");
            VelocityContext context = new VelocityContext();
            context.Put("Helper", helper);
            context.Put("Table", parseTable);
            foreach (DataGridViewRow row in DataGrid_Properties.Rows)
            {
                context.Put(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
            }
            string result = string.Empty;
            try
            {
                result = codeTemplate.ParseTemplate(context, "ColumnToProperty.tpl");
            }
            catch (Exception ex)
            {
                RtbCode.Text = ex.Message;
            }
            //写文件
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.WriteLine(result);
            sw.Close();
            sw.Dispose();
        }

        private void OpenFolderAndSelectFile(string filePath)
        {
            System.Diagnostics.Process.Start(filePath);
        }

        #endregion

        /// <summary>
        /// 打开生成目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenDir_Click(object sender, EventArgs e)
        {
            string filePath = string.Format(ConfigurationManager.AppSettings["Output"].ToString(), AppDomain.CurrentDomain.BaseDirectory);
            OpenFolderAndSelectFile(filePath);
        }

    }
}
