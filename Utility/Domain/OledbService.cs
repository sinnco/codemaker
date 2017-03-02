using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DMedia.Utility.Domain
{
    /// <summary>
    /// OleDb数据库，针对Access数据库等
    /// </summary>
    public class OledbService : IAdoService
    {
        public string Test(Connection conn)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAllDatabase(string connectionString)
        {
            OleDbConnection connect = new OleDbConnection();
            connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            throw new NotImplementedException();
        }

        public IList<Table> GetTables(Connection conn)
        {
            throw new NotImplementedException();
        }

        public Table GetTable(Connection conn, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
