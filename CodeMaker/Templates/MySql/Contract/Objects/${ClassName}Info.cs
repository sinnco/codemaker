/*----------------------------------------------------------------
// Copyright (C) 2012 重庆新媒农信科技有限公司 版权所有。  
//
// 文件名：${ClassName}Info.cs
// 文件功能描述：$Description 契约层实体定义
//
// 
// 创建标识：   $Author -- $CurrentTime 
//
// 修改标识：   
// 修改描述：   
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ${Project}.Utils;

namespace ${Project}.${Module}.Contract.Objects
{
    /// <summary>
    /// ${ClassName}Info $Description 契约层实体定义
    /// </summary>
    public class ${ClassName}Info
    {
#foreach($column in $Table.Columns)
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        public $Helper.MySqlToCS($column.DataType) $Helper.StringToPascal($column.Name) { get; set; }

#end
    }
    
    /// <summary>
    /// ${ClassName}Info $Description 条件
    /// </summary>
    public class ${ClassName}Condition : BaseCondition
    {
        public ${ClassName}Condition()
        {
            Status = 1;
        }

        /// <summary>
        /// 状态：1待审 2 初审(创建后) 3发布(可供下发业务使用) 4驳回 5回收站
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间 （开始）
        /// </summary>
        public string FromTime { get; set; }

        /// <summary>
        /// 创建时间 （结束）
        /// </summary>
        public string ToTime { get; set; }
    }
}