/*----------------------------------------------------------------
// Copyright (C) 2011 北京新媒传信科技有限公司 版权所有。 
//
// 文件名：${ClassName}.cs
// 文件功能描述：$Description 领域层实体定义(Model)
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

namespace ${Project}.${Module}.Domain.Model
{
    /// <summary>
    /// ${ClassName}  $Description 领域层实体定义(Model)
    /// </summary>
    public class ${ClassName}
    {
#foreach($column in $Table.Columns)
        /// <summary>
        /// $Helper.StringToSingleLine($column.Comments)
        /// </summary>
        public virtual $Helper.OracleToCS($column.DataType,$column.Length) $Helper.StringToPascal($column.Name) { get; set; }

#end

    }
}