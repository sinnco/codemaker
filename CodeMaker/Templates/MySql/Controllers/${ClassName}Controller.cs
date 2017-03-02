/*----------------------------------------------------------------
// Copyright (C) 2014 重庆新媒农信科技有限公司 版权所有。  
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
using DMedia.Athena.Core.Logging;
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
        #region Property Constuctor
        private I${ClassName}Service ${ClassName.ToLower()}Service;
        
        /// <summary>
        /// $Description 契约层服务组件
        /// </summary>
        public I${ClassName}Service ${ClassName}Service
        {
            get { return ${ClassName.ToLower()}Service ?? (${ClassName.ToLower()}Service = ${ClassName}ServiceFactory.Create()); }
        }
        #endregion

        #region 列表/搜索/详情
        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult List(${ClassName}DTO.SearchModel model)
        {
            model.Source.AssignedCpList = this.CurrentUser.AssignedCpList;
            model.List = ${ClassName}Service.Get${ClassName}List(model.Source);
            
            return View("../${Module}/${ClassName}/List", model);
        }
        
        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(string id)
        {
            ${ClassName}DTO.DetailModel model = new ${ClassName}DTO.DetailModel();
            model.Source = ${ClassName}Service.GetById(id);
            return View("../${Module}/${ClassName}/Detail", model);
        }
        
        #endregion

        #region 创建
        /// <summary>
        /// 创建$Description
        /// </summary>
        public ActionResult Create()
        {
            ${ClassName}DTO.SaveModel model = new ${ClassName}DTO.SaveModel();
            model.Source = new ${ClassName}Info()
            {              
            };
          
            return View("../${Module}/${ClassName}/CreateEdit", model);
        }

        /// <summary>
        /// 将新建$Description写入数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult DoCreate(${ClassName}DTO.SaveModel model)
        {
            AjaxMsgResult jsonResult = new AjaxMsgResult();

            try
            {
                UserInfo loginUser = this.CurrentUser;

                //model.Source.CpId = loginUser.CpId;
                model.Source.Createtime = DateTime.Now;
                //校验及排重逻辑
                
                //入库
                var identity = ${ClassName}Service.Insert(model.Source);
                jsonResult.Success = true;
            }
            catch (CustomizedException cx)
            {
                jsonResult.Msg = cx.Message;
            }
            catch (Exception ex)
            {
                Logging4net.WriteError(ex);
                jsonResult.Msg = ex.Message;          
            }
            return this.Json(jsonResult);
        }

        #endregion

        #region 编辑
        /// <summary>
        /// 编辑$Description
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            ${ClassName}DTO.SaveModel model = new ${ClassName}DTO.SaveModel();
            model.Source = ${ClassName}Service.GetById(id);
            return View("../${Module}/${ClassName}/CreateEdit", model);
        }

        /// <summary>
        /// 执行编辑
        /// </summary>
        /// <param name="updated"></param>
        /// <returns></returns>
        public ActionResult DoEdit(${ClassName}DTO.SaveModel model)
        {
            AjaxMsgResult jsonResult = new AjaxMsgResult();

            try
            {
                model.Source.Updatetime = DateTime.Now;
                //校验排重逻辑
                
                //入库修改
                UserInfo account = this.CurrentUser;
                ${ClassName}Service.Update(() => new ${ClassName}Info()
                {
                   
                }, where => where.Id == model.Source.Id);

                jsonResult.Success = true;
            }
            catch (CustomizedException cx)
            {
                jsonResult.Msg = cx.Message;
            }
            catch (Exception ex)
            {
                Logging4net.WriteError(ex);
                jsonResult.Msg = ex.Message;
            }
            return this.Json(jsonResult);
        }
        #endregion

        #region 发布/驳回/回收(删除)
        /// <summary>
        /// 删除$Description
        /// </summary>
        public ActionResult Recycle()
        {
            AjaxMsgResult ajaxResult = new AjaxMsgResult();

            string checkItem = RequestHelper.GetFormStrIds("id");
            string[] selectedItems = checkItem.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int sucessCount = 0, errorCount = 0;
            StringBuilder errBuilder = new StringBuilder();

            foreach (string item in selectedItems)
            {
                try
                {
                    ${ClassName}Service.Update(() => new ${ClassName}Info()
                    {
                       
                    }, where => where.Id == item);
      
                    sucessCount += 1;
                    //日志
                    //OperateLogingHelper.Instance.Info(SysModuleCode.Content_SmsGroup,
                    //    OperateCode.Recycle,
                    //    this.CurrentUser.Id,
                    //    item, "回收$Description");

                }
                catch (CustomizedException cx)
                {
                    errBuilder.AppendLine(string.Format("$Description{0}更新失败:{1}; ", item, cx.Message));
                    errorCount += 1;
                }
                catch (Exception e)
                {
                    errBuilder.AppendLine(string.Format("$Description{0}:更新异常 ", item));
                    Logging4net.WriteError(e, string.Format(" $Description{0}:更新异常", item));
                    errorCount += 1;
                    //日志
                    //OperateLogingHelper.Instance.Error(SysModuleCode.Content_SmsGroup,
                    //    OperateCode.Recycle,
                    //    this.CurrentUser.Id,
                    //    item, "回收$Description");
                }
            }

            ajaxResult.Msg = string.Format("成功处理{0}条", sucessCount);
            if (errorCount > 0)
            {
                ajaxResult.Msg += string.Format(",失败{0}条.", errorCount);
                ajaxResult.Msg += errBuilder.ToString();
            }
            ajaxResult.Success = sucessCount > 0 ? true : false;
            return this.Json(ajaxResult);
        }
        #endregion

    }
}