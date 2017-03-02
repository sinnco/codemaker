/*----------------------------------------------------------------
// Copyright (C) 2014 XinTian Media Cto.Ltd 版权所有。 
//
// 文件名：${ClassName}Map.cs
// 文件功能描述：$Description 领域层实体映射Map
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
using DMedia.Athena.Data;

namespace ${Project}.${Module}.Domain.Model
{
    /// <summary>
    /// ${ClassName}Map $Description 领域层实体映射Map
    /// </summary>
    public class ${ClassName}Map : DMClassMap<${ClassName}>
    {
        public ${ClassName}Map()
        {
            Table("$Table.Name");
#foreach($column in $Table.Columns)
#if($column.Property.ToLower()=="id")
            Id(a => a.$column.Property, "$column.Name");
#else
            Map(a => a.$column.Property, "$column.Name");
#end
#end
        }
    }
}