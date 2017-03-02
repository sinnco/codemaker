using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Contract
{
    public interface IAdoService
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="conn"></param>
        /// <returns>错误信息</returns>
        string Test(Connection conn);

        /// <summary>
        /// 返回所有数据库
        /// </summary>
        /// <returns></returns>
        IList<string> GetAllDatabase(string connectionString);

        /// <summary>
        /// 返回所有数据表
        /// </summary>
        /// <param name="conn">连接</param>
        /// <returns></returns>
        IList<Table> GetTables(Connection conn);

        /// <summary>
        /// 返回一个数据表
        /// </summary>
        /// <param name="conn">连接</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        Table GetTable(Connection conn, string tableName);
    }
}
