/*----------------------------------------------------------------
// Copyright (C) 2011 北京新媒传信科技有限公司 版权所有。 
//
// 文件名：${ClassName}Controller.cs
// 文件功能描述：$Description 控制层
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
using System.Web;
using System.Web.Mvc;
using DMedia.Athena.Data;
using ${Project}.Components.Base;
using ${Project}.${Module}.Contract.Builder;
using ${Project}.${Module}.Contract.Interfaces;
using ${Project}.${Module}.Contract.Objects;
using ${Project}.${Module}.Controllers.DTO;
using ${Project}.Utils;

namespace ${Project}.${Module}.Controllers
{
    /// <summary>
    /// ${ClassName}Controller $Description 控制层
    /// </summary>
    public class ${ClassName}Controller : BaseController
    {
        private I${ClassName}Service ${ClassName.ToLower()}Service;
        
        /// <summary>
        /// $Description 契约层服务组件
        /// </summary>
        public I${ClassName}Service ${ClassName}Service
        {
            get { return ${ClassName.ToLower()}Service ?? (${ClassName.ToLower()}Service = ${ClassName}ServiceFactory.Create()); }
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}