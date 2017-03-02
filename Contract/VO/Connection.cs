using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Contract
{
    public class Connection
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (this.DbType.ToUpper())
            {
                case "MSSQL":
                    return string.Concat("data source=", this.Server, ";initial catalog=", this.Database, ";user id=", this.Username, ";password=", Password);
                case "ORACLE":
                    return string.Concat("Data Source=", Database, ";User Id=", Username, ";Password=", Password, ";Pooling=true; Min Pool Size=0; Max Pool Size=512;");
                default:
                    return string.Concat("data source=", this.Server, ";initial catalog=", this.Database, ";user id=", this.Username, ";password=", Password);
            }
        }
    }
}
