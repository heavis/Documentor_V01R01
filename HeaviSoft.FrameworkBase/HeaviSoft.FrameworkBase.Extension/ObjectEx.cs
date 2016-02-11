using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Extension
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectEx
    {
        /// <summary>
        /// 判断是否是否为Null
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static bool IsNull(this Object obj)
        {
            return obj == null;
        }
    }
}
