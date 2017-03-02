/*----------------------------------------------------------------
// Copyright (C) 2011 北京新媒传信科技有限公司 版权所有。 
//
// 文件名：${ClassName}ServiceFactory.cs
// 文件功能描述：$Description 服务组件工厂生成类
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
using DMedia.Athena.Core.UnityEx;
using ${Project}.${Module}.Contract.Interfaces;

namespace ${Project}.${Module}.Contract.Builder
{
    /// <summary>
    /// 服务组件生成类，用于生成业务服务组件（工厂）
    /// </summary>
    public sealed class ${ClassName}ServiceFactory
    {
        /// <summary>
        /// 创建$Description  服务组件
        /// </summary>
        /// <returns></returns>
        public static I${ClassName}Service Create()
        {
            return UnityConfigEx.GetService<I${ClassName}Service>();
        }
    }
}