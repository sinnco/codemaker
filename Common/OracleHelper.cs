using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DMedia.Common
{
    public partial class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string OracleToCS(string type, long length)
        {
            switch (type.ToLower())
            {
                case "blob":
                case "clob":
                case "char":
                case "nclob":
                case "nvarchar2":
                case "varchar2":
                    return "string";

                case "date":
                    return "DateTime";

                case "number":
                    if (length < 10)
                    {
                        return "int";
                    }
                    return "long";
            }
            if (type.ToLower().StartsWith("timestamp"))
            {
                return "DateTime";
            }
            return "string";
        }

        public static string OracleToReader(string type)
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
                    return "GetByte";

                case "uniqueidentifier":
                    return "GetGuid";

                case "varchar":
                    return "GetString";
            }
            return "GetString";
        }

    }
}
