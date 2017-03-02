using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DMedia.Utility
{
    public class Table
    {
        #region 数据列
        private IList<ColumnSchema> columns;
        public IList<ColumnSchema> Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new List<ColumnSchema>();
                }
                return columns;
            }
        }
        #endregion

        /// <summary>
        /// 数据表名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 数据表描述
        /// </summary>
        public string Comments { get; set; }
    }
}
