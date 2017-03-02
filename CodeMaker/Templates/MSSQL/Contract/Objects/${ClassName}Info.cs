/*----------------------------------------------------------------
// Copyright (C) 2014 XinTian Media Cto.Ltd 版权所有。 
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
        public $Helper.OracleToCS($column.DataType,$column.Length) $Helper.StringToPascal($column.Name) { get; set; }

#end
    }

    /// <summary>
    /// ${ClassName}ExtensionResult
    /// </summary>
    public class ${ClassName}ExtensionResult
    {
        public IList<${ClassName}Info> ${ClassName}Collection { get; set; }
        
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
    }
    
}