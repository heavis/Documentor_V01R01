using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Core
{
    /// <summary>
    /// 应用对象类
    /// </summary>
    public abstract class ExtendedApplicationBase : Application
    {
        public readonly string PROPERTY_ACCOUNT = "ExtendedApplicationBase_Account";
        public readonly string PROPERTY_PASSWORD = "ExtendedApplicationBase_Password";

        /// <summary>
        /// 当前应用实例
        /// </summary>
        public static ExtendedApplicationBase Current { get; set; }

        public ExtendedApplicationBase() : base()
        {
            Data = new Dictionary<object, object>();
            ThemeResourceModules = new List<IThemeResourceModule>();
            LanguageResourceMudules = new List<ILanguageResourceModule>();
            LoginModules = new List<ILoginModule>();
            AuthenticationModules = new List<IAuthenticationModule>();
            AuthorizationModules = new List<IAuthorizationModule>();
            ExecutionModules = new List<IExecutionModule>();

            Context = new AppContext();
        }

        /// <summary>
        /// 应用上下文
        /// </summary>
        public AppContext Context { get; private set; }

        public Dictionary<object, object> Data { get; private set; }

        protected List<IThemeResourceModule> ThemeResourceModules { get; private set; }

        protected List<ILanguageResourceModule> LanguageResourceMudules { get; private set; }

        protected List<ILoginModule> LoginModules { get; private set; }

        protected List<IAuthenticationModule> AuthenticationModules { get; private set; }

        protected List<IAuthorizationModule> AuthorizationModules { get; private set; }

        protected List<IExecutionModule> ExecutionModules { get; private set; }

        /// <summary>
        /// 构建步骤
        /// </summary>
        public abstract void BuildSteps();

        /// <summary>
        /// 执行步骤
        /// </summary>
        /// <returns>执行状态</returns>
        public virtual bool ExecuteSteps()
        {
            if (!ExecuteThemeResourceModulesCore())
                return false;
            if (!ExecuteLanguageResourceModulesCore())
                return false;
            if (!ExecuteLoginModulesCore())
                return false;
            //if (!ExecuteAutheticationModulesCore())
            //   return false;
            if (!ExecuteAuthorizationModulesCore())
                return false;
            if (!ExecuteExecutionModulesCore())
                return false;

            return true;
        }

        /// <summary>
        /// 关闭系统
        /// </summary>
        public virtual void ExitEx()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 执行主题资源加载
        /// </summary>
        /// <returns></returns>
        protected abstract bool ExecuteThemeResourceModulesCore();

        /// <summary>
        /// 执行语言资源加载
        /// </summary>
        /// <returns></returns>
        protected abstract bool ExecuteLanguageResourceModulesCore();

        /// <summary>
        /// 执行登录流程
        /// </summary>
        /// <returns></returns>
        protected abstract bool ExecuteLoginModulesCore();
        /// <summary>
        /// 执行身份验证
        /// </summary>
        /// <returns></returns>
        public abstract bool ExecuteAutheticationModulesCore();
        /// <summary>
        /// 执行身份授权
        /// </summary>
        /// <returns></returns>
        protected abstract bool ExecuteAuthorizationModulesCore();
        /// <summary>
        /// 执行常规流程
        /// </summary>
        /// <returns></returns>
        protected abstract bool ExecuteExecutionModulesCore();

        /// <summary>
        /// 激活当前应用
        /// </summary>
        public void Activate()
        {
            this.MainWindow.Show();
            this.MainWindow.Activate();
        }
    }
}
