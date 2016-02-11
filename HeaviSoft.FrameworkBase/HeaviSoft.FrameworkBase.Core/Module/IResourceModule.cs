using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.Module
{
    /// <summary>
    /// 资源加载模块
    /// </summary>
    public interface IResourceModule
    {
        /// <summary>
        /// 资源加载中
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="name">资源名称</param>
        /// <returns></returns>
        bool Loading(ExtendedApplicationBase app, string name);
        /// <summary>
        /// 资源加载完成
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="name">资源名称</param>
        /// <returns></returns>
        bool Loaded(ExtendedApplicationBase app, string name);
        /// <summary>
        /// 资源卸载中
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="name">资源名称</param>
        /// <returns></returns>
        bool UnLoading(ExtendedApplicationBase app, string name);
        /// <summary>
        /// 资源卸载完成
        /// </summary>
        /// <param name="app">应用对象</param>
        /// <param name="name">资源名称</param>
        /// <returns></returns>
        bool UnLoaded(ExtendedApplicationBase app, string name);
    }
}
