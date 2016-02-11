using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Module
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public interface IAuthorizationModule
    {
        /// <summary>
        /// 身份授权
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <returns>授权状态</returns>
        bool Authorize(ExtendedApplicationBase app);
    }
}
