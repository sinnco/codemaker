using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Common
{
    public partial class Helper
    {

        /// <summary>
        /// SQL转换为C#类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string MySqlToCS(string type)
        {
            switch (type.ToLower())
            {
                case "bigint": return "long";
                case "blob": return "byte[]";
                case "bit": return "bool";
                case "char": return "string";
                case "date": return "DateTime";
                case "datetime": return "DateTime";
                case "decimal": return "decimal";
                case "double": return "double";
                case "enum": return "string";
                case "float": return "float";
                case "image": return "Image";
                case "int": return "int";
                case "longblob": return "byte[]";
                case "mediumblob": return "byte[]";
                case "mediumint": return "int";
                case "ntext": return "string";
                case "numeric": return "decimal";
                case "nvarchar": return "string";
                case "real": return "Real";
                case "smalldatetime": return "DateTime";
                case "smallint": return "short";
                case "text": return "string";
                case "time": return "DateTime";
                case "timestamp": return "DateTime";
                case "tinyblob": return "byte[]";
                case "tinyint": return "byte";
                case "uniqueidentifier": return "Guid";
                case "varbinary": return "List<byte>";
                case "varchar": return "string";
                case "Year": return "DateTime";
                default: return "string";
            }
        }

        public static string MySqlToReader(string type)
        {
            switch (type)
            {
                case "bigint": return "GetInt64";
                //case "binary": return "byte[]";
                case "bit": return "GetBoolean";
                case "char": return "GetString";
                case "datetime": return "GetDateTime";
                case "decimal": return "GetDecimal";
                case "float": return "GetFloat";
                //case "image": return "Image";
                case "int": return "GetInt32";
                case "money": return "GetDouble";
                case "nchar": return "GetString";
                case "ntext": return "GetString";
                case "numeric": return "GetDecimal";
                case "nvarchar": return "GetString";
                //case "real": return "Real";
                case "smalldatetime": return "GetDateTime";
                case "smallint": return "GetInt16";
                case "smallmoney": return "GetDouble";
                //case "sql_variant": return "Variant";
                case "text": return "GetString";
                //case "timestamp": return "Timestamp";
                case "tinyint": return "GetByte";
                case "uniqueidentifier": return "GetGuid";
                //case "varbinary": return "List<byte>";
                case "varchar": return "GetString";
                default: return "GetString";
            }
        }

    }
}
