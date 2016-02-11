using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Module
{
    /// <summary>
    /// 身份认证
    /// </summary>
    public interface IAuthenticationModule
    {
        /// <summary>
        /// 身份认证
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <returns>认证状态</returns>
        bool Authenticate(ExtendedApplicationBase app);
    }
}
