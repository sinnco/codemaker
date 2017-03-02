using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Contract
{
    public class ColumnSchema : Column
    {
        /// <summary>
        /// 是否需要验证
        /// </summary>
        public bool Validate { get; set; }
        /// <summary>
        /// 使用控件
        /// </summary>
        public string Control { get; set; }
    }
}
