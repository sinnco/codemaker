/*----------------------------------------------------------------
// Copyright (C) 2012 重庆新媒农信科技有限公司 版权所有。  
//
// 文件名：${ClassName}Service.cs
// 文件功能描述：$Description 领域层服务实现
//
// 
// 创建标识：   $Author -- $CurrentTime 
//
// 修改标识：   
// 修改描述：   
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DMedia.Athena.Core;
using DMedia.Athena.Data;
using ${Project}.${Module}.Contract.Interfaces;
using ${Project}.${Module}.Contract.Objects;
using ${Project}.${Module}.Domain.Model;

namespace ${Project}.${Module}.Domain.Service
{
    /// <summary>
    /// ${ClassName}Service $Description 领域层服务实现
    /// </summary>
    public class ${ClassName}Service : Repository<${ClassName}Info, ${ClassName}>, I${ClassName}Service
    {
	      /// <summary>
        /// 根据条件获取$Description 分页
        /// </summary>
        /// <param name="conditionWhere"></param>
        /// <returns></returns>
        public IList<${ClassName}Info> Get${ClassName}List(${ClassName}Condition conditionWhere)
        {
            //参数
            StringBuilder conditionBuiler = new StringBuilder();
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            //默认条件及CP
            //conditionBuiler.Append(" TYPE_ID = 2 ");
            //conditionBuiler.Append(conditionWhere.CpBuildSqlWhere());
            
            //自定义条件
     
            PagingInfo pagingInfo = new PagingInfo
            {
                Conditions = conditionBuiler.ToString(),
                TableName = " $Table.Name ",
                Fileds = " * ",
                GroupFields = "",
                SortFields = "",
                KeyField = "",
                PageIndex = conditionWhere.PageIndex,
                PageSize = conditionWhere.PageSize,
                Parameters = parameters,
            };
            //查询结果
            IList<${ClassName}Info> result = DataHelper.GetPagingData<${ClassName}Info>(pagingInfo);
            conditionWhere.PageIndex = pagingInfo.PageIndex;
            conditionWhere.PageSize = pagingInfo.PageSize;
            conditionWhere.PageCount = pagingInfo.PageCount;
            conditionWhere.RecordCount = pagingInfo.RecordCount;
            return result;
        }

    }
}
