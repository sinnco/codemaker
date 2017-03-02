/*----------------------------------------------------------------
// Copyright (C) 2014 重庆新媒农信科技有限公司 版权所有。 
//
// 文件名： ${ClassName}DTO.cs
// 文件功能描述： $Description DTO 页面传输对象
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
using System.Web.Mvc;
using ${Project}.Components.Base;
using ${Project}.${Module}.Contract.Objects;
using ${Project}.Utils;

namespace ${Project}.${Module}.Controllers.DTO
{
    /// <summary>
    /// ${ClassName} DTO $Description页面传输对象
    /// </summary>
    public class ${ClassName}DTO
    {
        /// <summary>
        /// $Description 修改模型
        /// </summary>
        public class SaveModel : BaseDTO<${ClassName}Info>
        {
            #region Fields
#foreach($column in $Table.Columns)
            /// <summary>
            /// $Helper.StringToSingleLine($column.Comments)
            /// </summary>
            public $Helper.MySqlToCS($column.DataType) $Helper.StringToPascal($column.Name)
            {
                get { return Source.$Helper.StringToPascal($column.Name); }
                set { Source.$Helper.StringToPascal($column.Name) = value; }
            }
            
#end
           #endregion
        }
        
        /// <summary>
        /// $Description 详情模型
        /// </summary>
        public class DetailModel : BaseDTO<${ClassName}Info>
        {
            #region Fields
#foreach($column in $Table.Columns)
            /// <summary>
            /// $Helper.StringToSingleLine($column.Comments)
            /// </summary>
            public $Helper.MySqlToCS($column.DataType) $Helper.StringToPascal($column.Name)
            {
                get { return Source.$Helper.StringToPascal($column.Name); }
                set { Source.$Helper.StringToPascal($column.Name) = value; }
            }
            
#end
           #endregion
        }

        /// <summary>
        /// $Description 搜索模型，用户列表、条件查询
        /// </summary>
        [Bind(Exclude = "List")]
        public class SearchModel : PageListDTO<${ClassName}Condition,${ClassName}Info>
        {
            /// <summary>
            /// 状态：1待审 2 初审(创建后) 3发布(可供下发业务使用) 4驳回 5回收站
            /// </summary>
            public int Status
            {
                get { return Source.Status; }
                set { Source.Status = value; }
            }

            /// <summary>
            /// 创建时间 （开始）
            /// </summary>
            public string FromTime
            {
                get { return Source.FromTime; }
                set { Source.FromTime = value; }
            }

            /// <summary>
            /// 创建时间 （结束）
            /// </summary>
            public string ToTime
            {
                get { return Source.ToTime; }
                set { Source.ToTime = value; }
            }
        }

    }//end class
}