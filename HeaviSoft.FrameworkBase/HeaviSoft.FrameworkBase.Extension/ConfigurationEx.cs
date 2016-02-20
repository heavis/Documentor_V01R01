using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeaviSoft.FrameworkBase.Extension
{
    public static class ConfigurationEx
    {
        /// <summary>
        /// 获取节点元素的属性值集合
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="attr">属性</param>
        /// <param name="eleLayouts">元素层次集合</param>
        /// <returns></returns>
        public static List<string> GetAtrriuteValues(this XElement parent, string attr, string[] eleLayouts)
        {
            if (attr.IsNull() || eleLayouts.IsNull() || eleLayouts.Length == 0)
            {
                throw new ArgumentException("attr and eleLayouts can't be null.");
            }
            var list = new List<string>();
            try
            {
                var childElement = parent;
                for(var i = 0; i < eleLayouts.Length - 1; i++)
                {
                       childElement = childElement.Elements().FirstOrDefault(el => el.Name.LocalName == eleLayouts[i]);
                }
                list.AddRange(childElement.Elements().Where(el => el.Name.LocalName == eleLayouts[eleLayouts.Length - 1]).Select(xle => xle.Attributes().FirstOrDefault(at => at.Name.LocalName == "Type").Value).ToList());
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static IEnumerable<XElement> GetElements(this XElement parent,  string[] eleLayouts)
        {
            if (eleLayouts.IsNull() || eleLayouts.Length == 0)  
            {
                throw new ArgumentException("eleLayouts can't be null.");
            }
            var list = new List<XElement>();
            try
            {
                var childElement = parent;
                for (var i = 0; i < eleLayouts.Length - 1; i++)
                {
                    childElement = childElement.Elements().FirstOrDefault(el => el.Name.LocalName == eleLayouts[i]);
                }
                list.AddRange(childElement.Elements().Where(el => el.Name.LocalName == eleLayouts[eleLayouts.Length - 1]).ToList());
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static string GetAttributeValue(this XElement element, string attr)
        {
            try
            {
                return element.Attributes().FirstOrDefault(at => at.Name.LocalName == attr).Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
