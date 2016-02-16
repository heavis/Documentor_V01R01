using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Module
{
    /// <summary>
    /// 登录模块
    /// </summary>
    public interface ILoginModule
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <returns>返回登陆操作状态</returns>
        bool Login(ExtendedApplicationBase app);
        /// <summary>
        /// 登录成功
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="message">成功消息</param>
        void LoginSuccessed(ExtendedApplicationBase app, object message);
        /// <summary>
        /// 登录失败
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="message">失败消息</param>
        void LoginFailed(ExtendedApplicationBase app, object message);
    }
}
