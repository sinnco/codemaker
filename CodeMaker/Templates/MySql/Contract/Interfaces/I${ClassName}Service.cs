/*----------------------------------------------------------------
// Copyright (C) 2012 重庆新媒农信科技有限公司 版权所有。  
//
// 文件名：I${ClassName}Service.cs
// 文件功能描述：$Description 契约层接口定义
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
using ${Project}.${Module}.Contract.Objects;
using ${Project}.Utils;

namespace ${Project}.${Module}.Contract.Interfaces
{
    /// <summary>
    /// $Description 契约层接口定义
    /// </summary>
    public interface I${ClassName}Service : IRepository<${ClassName}Info>
    {
		    /// <summary>
        /// 根据条件获取$Description 分页
        /// </summary>
        /// <param name="conditionWhere"></param>
        /// <returns></returns>
        IList<${ClassName}Info> Get${ClassName}List(${ClassName}Condition conditionWhere);
    }
}
