using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace DMedia.Utility
{
    public class OracleService : IAdoService
    {
        #region IAdoService 成员

        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public IList<string> GetAllDatabase(string connectionString)
        {
            string path = ConfigurationManager.AppSettings["TNS"].ToString();
            string input = "";
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                input = new StreamReader(stream).ReadToEnd();
            }
            MatchCollection matchs = new Regex(@"\n(\w+\s)=", RegexOptions.Singleline).Matches(input);
            IList<string> list = new List<string>();
            foreach (Match match in matchs)
            {
                list.Add(match.Groups[1].ToString());
            }
            return list;
        }

        /// <summary>
        /// 获取某个表的表结构
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Table GetTable(Connection conn, string tableName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT A.TABLE_NAME,");
            builder.Append("       A.COLUMN_NAME,");
            builder.Append("       A.DATA_TYPE,");
            builder.Append("       A.DATA_LENGTH,");
            builder.Append("       A.DATA_PRECISION,");
            builder.Append("       A.NULLABLE,");
            builder.Append("       A.DATA_DEFAULT,");
            builder.Append("       A.CHAR_LENGTH,");
            builder.Append("       A.DATA_SCALE,");
            builder.Append("       B.COMMENTS,");
            builder.Append("       C.COMMENTS TABLECOMMENTS");
            builder.Append("  FROM USER_TAB_COLUMNS A");
            builder.Append("  LEFT OUTER JOIN user_col_comments B");
            builder.Append("    ON A.table_name = B.table_name");
            builder.Append("   and A.column_name = B.column_name");
            builder.Append("  LEFT OUTER JOIN user_tab_comments C");
            builder.Append("    ON A.table_name = C.table_name");
            builder.Append(" WHERE A.TABLE_NAME = '");
            builder.Append(tableName);
            builder.Append("'");
            builder.Append(" ORDER BY A.TABLE_NAME, A.COLUMN_ID");
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    new OracleDataAdapter(builder.ToString(), connection).Fill(dataTable);
                }
                catch (Exception exception)
                {
                    connection.Close();
                    connection.Dispose();
                    throw exception;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            Table table2 = new Table();
            table2.Name = dataTable.Rows[0]["TABLE_NAME"].ToString();
            table2.Comments = dataTable.Rows[0]["TABLECOMMENTS"].ToString();
            table2.Database = conn.Database;
            string str = string.Empty;
            string str2 = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ColumnSchema item = new ColumnSchema();
                item.Name = dataTable.Rows[i]["COLUMN_NAME"].ToString();
                item.Property = dataTable.Rows[i]["COLUMN_NAME"].ToString().Replace("_", "");
                item.DataType = dataTable.Rows[i]["DATA_TYPE"].ToString();
                if (item.DataType.StartsWith("NUMBER") || item.DataType.StartsWith("TIMESTAMP"))
                {
                    str = (dataTable.Rows[i]["DATA_PRECISION"].ToString() == "0") ? "" : dataTable.Rows[i]["DATA_PRECISION"].ToString();
                    str2 = (dataTable.Rows[i]["DATA_SCALE"].ToString() == "0") ? "" : dataTable.Rows[i]["DATA_SCALE"].ToString();
                    if (string.IsNullOrEmpty(str) && string.IsNullOrEmpty(str2))
                    {
                        item.Length = 0;
                    }
                    else
                    {
                        item.Length = Convert.ToInt32(str + str2);
                    }
                }
                else
                {
                    item.Length = Convert.ToInt32(dataTable.Rows[i]["CHAR_LENGTH"].ToString());
                }
                item.IsNullAble = dataTable.Rows[i]["NULLABLE"].ToString() == "Y";
                item.DefaultValue = dataTable.Rows[i]["DATA_DEFAULT"].ToString();
                item.Comments = dataTable.Rows[i]["COMMENTS"].ToString();
                table2.Columns.Add(item);
            }
            return table2;
        }

        public IList<Table> GetTables(Connection conn)
        {
            string selectCommandText = "select TABLE_NAME from user_tables ORDER BY TABLE_NAME ASC";
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    new OracleDataAdapter(selectCommandText, connection).Fill(dataTable);
                }
                catch (Exception exception)
                {
                    connection.Close();
                    connection.Dispose();
                    throw exception;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            if (dataTable.Rows.Count == 0)
            {
                return new List<Table>();
            }
            IList<Table> list = new List<Table>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Table item = new Table();
                item.Name = dataTable.Rows[i][0].ToString();
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// 测试数据库链接
        /// </summary>
        /// <param name="conn">数据库链接Connection</param>
        /// <returns>为空则连接成功</returns>
        public string Test(Connection conn)
        {
            string message = "";
            string selectCommandText = "select * from gv$instance";
            DataTable dataTable = new DataTable();
            OracleConnection selectConnection = null;
            try
            {
                selectConnection = new OracleConnection(conn.ToString());
                selectConnection.Open();
                new OracleDataAdapter(selectCommandText, selectConnection).Fill(dataTable);
            }
            catch (Exception exception)
            {
                if (selectConnection != null)
                {
                    selectConnection.Close();
                    selectConnection.Dispose();
                }
                //  message = exception.Message;
            }
            finally
            {
                if (selectConnection != null)
                {
                    selectConnection.Close();
                    selectConnection.Dispose();
                }
            }
            return message;
        }

        #endregion
    }
}
