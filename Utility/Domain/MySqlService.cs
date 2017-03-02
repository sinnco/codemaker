using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DMedia.Utility
{
    public class MySqlService : IAdoService
    {
        public string Test(Connection conn)
        {
            try
            {
                string connectionString = string.Concat("Server=", conn.Server, ";Database=", conn.Database, ";Uid=", conn.Username, ";Pwd=", conn.Password, ";");
                this.GetAllDatabase(connectionString);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public IList<string> GetAllDatabase(string connectionString)
        {
            string commandText = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA ORDER BY SCHEMA_NAME";

            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(commandText, connection);
                    command.Fill(dataTable);
                }
                catch (MySqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            //如果没有数据
            if (dataTable.Rows.Count == 0)
            {
                return new List<string>();
            }
            IList<string> result = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                result.Add(dataTable.Rows[i][0].ToString());
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<Table> GetTables(Connection conn)
        {
            string commandText = string.Format("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}' ORDER BY TABLE_NAME", conn.Database);

            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(commandText, connection);
                    command.Fill(dataTable);
                }
                catch (MySqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            //如果没有数据
            if (dataTable.Rows.Count == 0)
            {
                return new List<Table>();
            }
            IList<Table> result = new List<Table>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                result.Add(new Table() { Name = dataTable.Rows[i][0].ToString() });
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Table GetTable(Connection conn, string tableName)
        {
            StringBuilder sb = new StringBuilder(524);
            sb.AppendLine(@"SELECT C.TABLE_NAME,");
            sb.AppendLine(@"       C.COLUMN_NAME,");
            sb.AppendLine(@"       C.DATA_TYPE,");
            sb.AppendLine(@"       C.CHARACTER_MAXIMUM_LENGTH DATA_LENGTH,");
            sb.AppendLine(@"       C.NUMERIC_PRECISION        DATA_PRECISION,");
            sb.AppendLine(@"       C.IS_NULLABLE              NULLABLE,");
            sb.AppendLine(@"       C.COLUMN_DEFAULT           DATA_DEFAULT,");
            sb.AppendLine(@"       C.COLUMN_TYPE,");
            sb.AppendLine(@"       C.COLUMN_COMMENT,");
            sb.AppendLine(@"       T.TABLE_COMMENT");
            sb.AppendLine(@"  FROM INFORMATION_SCHEMA.COLUMNS C");
            sb.AppendLine(@"  LEFT JOIN INFORMATION_SCHEMA.TABLES T");
            sb.AppendLine(@"    ON C.TABLE_NAME = T.TABLE_NAME");
            sb.AppendLine(@" WHERE C.TABLE_NAME = ");
            sb.AppendFormat("'{0}'", tableName);
            sb.AppendLine(string.Format(@" AND C.TABLE_SCHEMA = '{0}' ", conn.Database));
            sb.AppendLine(string.Format(@" AND T.TABLE_SCHEMA =  '{0}'", conn.Database));
            sb.AppendLine(@" ORDER BY C.TABLE_NAME, C.ORDINAL_POSITION");

            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(sb.ToString(), connection);
                    command.Fill(dataTable);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw ex;
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
            Table table = new Table();
            table.Name = dataTable.Rows[0]["TABLE_NAME"].ToString();
            table.Comments = dataTable.Rows[0]["TABLE_COMMENT"].ToString();
            table.Database = conn.Database;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ColumnSchema column = new ColumnSchema();
                column.Name = dataTable.Rows[i]["COLUMN_NAME"].ToString();
                column.Property = dataTable.Rows[i]["COLUMN_NAME"].ToString().Replace("_", "");
                column.DataType = dataTable.Rows[i]["DATA_TYPE"].ToString();

                if (column.DataType.Equals("varchar") || column.DataType.Equals("char"))
                {
                    column.DataLength = Convert.ToInt32(dataTable.Rows[i]["DATA_LENGTH"].ToString());
                    column.CharLength = Convert.ToInt32(dataTable.Rows[i]["DATA_LENGTH"].ToString());
                }
                else if (column.DataType.Equals("int"))
                {
                    string columnType = dataTable.Rows[i]["COLUMN_TYPE"].ToString();
                    int leftBracket = columnType.IndexOf("(");
                    if (leftBracket > 0)
                    {
                        string columnLeft = columnType.Substring(leftBracket);
                        columnLeft = columnLeft.TrimStart(new char[] { '(', ')' }).TrimEnd(new char[] { '(', ')' });
                        int iColumnLen = int.Parse(columnLeft);
                        if (iColumnLen > 8)
                        {
                            column.DataType = "bigint";
                        }
                        column.DataLength = iColumnLen;
                    }
                }

                //column.DataLength = Convert.ToInt32(dataTable.Rows[i]["DATA_LENGTH"].ToString());
                //column.CharLength = Convert.ToInt32(dataTable.Rows[i]["CHAR_LENGTH"].ToString());
                column.IsNullAble = dataTable.Rows[i]["NULLABLE"].ToString() == "YES" ? true : false;
                column.DefaultValue = dataTable.Rows[i]["DATA_DEFAULT"].ToString() == "NULL" ? "" : dataTable.Rows[i]["DATA_DEFAULT"].ToString();
                column.Comments = dataTable.Rows[i]["COLUMN_COMMENT"].ToString();
                table.Columns.Add(column);
            }

            return table;
        }


        public IList<Table> GetTables(Connection conn, string database)
        {
            throw new NotImplementedException();
        }
    }
}
