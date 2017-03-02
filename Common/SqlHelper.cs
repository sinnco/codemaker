using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Common
{
    public partial class Helper
    {
        /// <summary>
        /// SQLServer类型转换为C#类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string SqlToCS(string type, long length = 8)
        {
            switch (type.ToLower())
            {
                case "bigint":
                    return "long";

                case "binary":
                    return "byte[]";

                case "bit":
                    return "bool";

                case "char":
                    return "string";

                case "datetime":
                    return "DateTime";

                case "decimal":
                    return "decimal";

                case "float":
                    return "float";

                case "image":
                    return "Image";

                case "int":
                    return "int";

                case "money":
                    return "double";

                case "nchar":
                    return "string";

                case "ntext":
                    return "string";

                case "numeric":
                    return "decimal";

                case "nvarchar":
                    return "string";

                case "real":
                    return "Real";

                case "smalldatetime":
                    return "DateTime";

                case "smallint":
                    return "short";

                case "smallmoney":
                    return "double";

                case "sql_variant":
                    return "Variant";

                case "text":
                    return "string";

                case "timestamp":
                    return "Timestamp";

                case "tinyint":
                    return "int";

                case "uniqueidentifier":
                    return "Guid";

                case "varbinary":
                    return "List<byte>";

                case "varchar":
                    return "string";
            }
            return "string";
        }

        /// <summary>
        /// SQL类型读取
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SqlToReader(string type)
        {
            switch (type)
            {
                case "bigint":
                    return "GetInt64";

                case "bit":
                    return "GetBoolean";

                case "char":
                    return "GetString";

                case "datetime":
                    return "GetDateTime";

                case "decimal":
                    return "GetDecimal";

                case "float":
                    return "GetFloat";

                case "int":
                    return "GetInt32";

                case "money":
                    return "GetDouble";

                case "nchar":
                    return "GetString";

                case "ntext":
                    return "GetString";

                case "numeric":
                    return "GetDecimal";

                case "nvarchar":
                    return "GetString";

                case "smalldatetime":
                    return "GetDateTime";

                case "smallint":
                    return "GetInt16";

                case "smallmoney":
                    return "GetDouble";

                case "text":
                    return "GetString";

                case "tinyint":
                    return "GetInt32";

                case "uniqueidentifier":
                    return "GetGuid";

                case "varchar":
                    return "GetString";
            }
            return "GetString";
        }

    }
}
