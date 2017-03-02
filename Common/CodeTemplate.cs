using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.Collections;
using NVelocity;
using NVelocity.App;

namespace DMedia.Common
{
    public class CodeTemplate
    {
        string componentFolder = "/Templates/";
        private VelocityEngine engine = new VelocityEngine();
        private ExtendedProperties props = new ExtendedProperties();

        public string ComponentFolder
        {
            set { componentFolder = value; }
            get { return componentFolder; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public CodeTemplate(string subPath)
        {
            props.AddProperty("file.resource.loader.path", Application.StartupPath);
            engine.Init(props);
            if (!string.IsNullOrEmpty(subPath))
            {
                componentFolder = string.Concat(componentFolder, subPath, "/");
            }
        }

        #region 解析组件视图
        /// <summary>
        /// 生成模板内容
        /// </summary>
        /// <param name="context">当前应用上下文</param>
        /// <param name="view">模板文件</param>
        /// <returns></returns>
        public string ParseTemplate(VelocityContext context, string view)
        {
            string targetComponent = Path.Combine(componentFolder, view);

            if (!engine.TemplateExists(targetComponent))
            {
                throw new InvalidOperationException("没有找到模板文件 '" + targetComponent + "'");
            }

            //加载模板
            Template template = engine.GetTemplate(targetComponent);

            StringWriter writer = new StringWriter();
            template.Merge(context, writer);

            return writer.GetStringBuilder().ToString();
        }
        #endregion
    }
}
