using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Extension
{
    /// <summary>
    /// 集合扩展
    /// </summary>
    public static class CollectionEx
    {
        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="list">集合对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IList list)
        {
            return list == null || list.Count > 0;
        }
    }
}
