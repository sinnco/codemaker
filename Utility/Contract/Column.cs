using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMedia.Utility
{
    public class Column
    {
        /// <summary>
        /// 标识
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 占用字节数
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public int DataLength { get; set; }
        /// <summary>
        /// 字符长度
        /// </summary>
        public int CharLength { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int DecimalDigits { get; set; }
        /// <summary>
        /// 允许空
        /// </summary>
        public bool IsNullAble { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Comments { get; set; }
    }
}
