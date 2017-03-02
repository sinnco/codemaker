using System;
using DMedia.Contract;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DMedia.Domain
{
    public class MsSqlService : IAdoService
    {

        #region IAdoService 成员

        public string Test(Connection conn)
        {
            try
            {
                string connectionString = string.Concat("data source=", conn.Server, ";user id=", conn.Username, ";password=", conn.Password);
                this.GetAllDatabase(connectionString);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }

        public IList<string> GetAllDatabase(string connectionString)
        {
            string commandText = "select name from master.dbo.sysdatabases where name not in('master','tempdb','model','msdb') Order by Name";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(commandText, connection);
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

        public IList<Table> GetTables(Connection conn)
        {
            string commandText = "select name from dbo.sysobjects where xtype='u' and (not name like 'dtproperties') order by name";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(commandText, connection);
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

        public Table GetTable(Connection conn, string tableName)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT ");
            commandText.Append("     TableName      = case when a.colorder=1 then d.name else '' end, ");
            commandText.Append("     TableDescription    = case when a.colorder=1 then isnull(f.value,'') else '' end, ");
            commandText.Append("     [Index] = a.colorder, ");
            commandText.Append("    [Name]    = a.name, ");
            commandText.Append("    IsIdentity      = case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end, ");
            commandText.Append("    IsPrimaryKey      = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in ( ");
            commandText.Append("                     SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√' else '' end, ");
            commandText.Append("    DataType      = b.name, ");
            commandText.Append("    Length= a.length, ");
            commandText.Append("    [Size]      = COLUMNPROPERTY(a.id,a.name,'PRECISION'), ");
            commandText.Append("    DecimalDigits = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0), ");
            commandText.Append("    IsNullAble    = case when a.isnullable=1 then '√'else '' end, ");
            commandText.Append("    DefaultValue    = isnull(e.text,''), ");
            commandText.Append("    Description = isnull(g.[value],'') ");
            commandText.Append("FROM ");
            commandText.Append("    syscolumns a ");
            commandText.Append("left join ");
            commandText.Append("    systypes b ");
            commandText.Append("on ");
            commandText.Append("    a.xusertype=b.xusertype ");
            commandText.Append("inner join ");
            commandText.Append("    sysobjects d ");
            commandText.Append("on ");
            commandText.Append("    a.id=d.id and d.xtype='U' and d.name<>'dtproperties' ");
            commandText.Append("left join ");
            commandText.Append("    syscomments e ");
            commandText.Append("on ");
            commandText.Append("    a.cdefault=e.id ");
            commandText.Append("left join ");
            commandText.Append("sys.extended_properties   g ");
            commandText.Append("on ");
            commandText.Append("    a.id=G.major_id and a.colid=g.minor_id  ");
            commandText.Append("left join ");
            commandText.Append("sys.extended_properties f ");
            commandText.Append("on ");
            commandText.Append("    d.id=f.major_id and f.minor_id=0 ");
            commandText.Append("where ");
            commandText.Append(" d.name='").Append(tableName).Append("'");//只查询指定表
            commandText.Append("order by ");
            commandText.Append("    a.id,a.colorder");

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conn.ToString()))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(commandText.ToString(), connection);
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
            table.Name = dataTable.Rows[0]["TableName"].ToString();
            table.Comments = dataTable.Rows[0]["TableDescription"].ToString();
            table.Database = conn.Database;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ColumnSchema column = new ColumnSchema();
                column.IsIdentity = dataTable.Rows[i]["IsIdentity"].ToString() == "√" ? true : false;
                column.IsPrimaryKey = dataTable.Rows[i]["IsPrimaryKey"].ToString() == "√" ? true : false;
                column.Name = dataTable.Rows[i]["Name"].ToString();
                column.Property = dataTable.Rows[i]["Name"].ToString().Replace("_", "");
                column.DataType = dataTable.Rows[i]["DataType"].ToString();
                column.Length = Convert.ToInt64(dataTable.Rows[i]["Length"].ToString());
                column.Size = Convert.ToInt32(dataTable.Rows[i]["Size"].ToString());
                column.DecimalDigits = Convert.ToInt32(dataTable.Rows[i]["DecimalDigits"].ToString());
                column.IsNullAble = dataTable.Rows[i]["IsNullAble"].ToString() == "√" ? true : false;
                column.DefaultValue = dataTable.Rows[i]["DefaultValue"].ToString();
                column.Comments = dataTable.Rows[i]["Description"].ToString();
                table.Columns.Add(column);
            }

            return table;
        }

        #endregion
    }
}
