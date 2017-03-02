using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DMedia.Common
{
    public partial class Helper
    {
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="keyValues"></param>
        public static void SetAppSetting(Dictionary<string, string> keyValues)
        {
            string filename = Application.ExecutablePath + ".config";
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("//appSettings");
            foreach (KeyValuePair<string, string> pair in keyValues)
            {
                XmlElement element = (XmlElement)node.SelectSingleNode("//add[@key='" + pair.Key + "']");
                if (element != null)
                {
                    element.SetAttribute("value", pair.Value);
                }
                else
                {
                    XmlElement newChild = document.CreateElement("add");
                    newChild.SetAttribute("key", pair.Key);
                    newChild.SetAttribute("value", pair.Value);
                    node.AppendChild(newChild);
                }
            }
            document.Save(filename);
        }

        /// <summary>
        /// 获取Pascal名称
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StringToPascal(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            string[] strArray = source.ToLower().Split(new char[] { '_' });
            source = string.Empty;
            for (int i = 0; i < strArray.Length; i++)
            {
                source = source + strArray[i].Substring(0, 1).ToUpper() + strArray[i].Substring(1).ToLower();
            }
            return source;
        }

        /// <summary>
        /// 去除空行
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StringToSingleLine(string source)
        {
            return source.Replace("\r\n", " ").Replace(Convert.ToChar(10).ToString(), "").Replace(Convert.ToChar(13).ToString(), "");
        }
    }
}
