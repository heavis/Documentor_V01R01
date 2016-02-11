using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Core.ExpcetionEx;
using HeaviSoft.FrameworkBase.Core.Module;
using HeaviSoft.FrameworkBase.Extension;
using HeaviSoft.FrameworkBase.Utility.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Client
{
    /// <summary>
    /// 系统应用
    /// </summary>
    internal class ExtendedApplication : ExtendedApplicationBase
    {
        /// <summary>
        /// 流程启动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //注册事件
            this.DispatcherUnhandledException += ExtendedApplication_DispatcherUnhandledException;
            //开始构建步骤
            try
            {
                this.BuildSteps();
                //执行步骤
                if (!this.ExecuteSteps())
                {
                    //步骤未执行成功
                }
            }
            catch (Exception ex)
            {
                //写日志
                Logger.Error("Error occured during appication start-up.");
                throw ex;
            }

        }

        /// <summary>
        /// 未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtendedApplication_DispatcherUnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //写日志
            Logger.Error("Unknown error.", e.Exception);

            //启动过程中发生了异常。
            if (e.Exception is StartupException)
            {
                //启动异常提示
            }
            else if(e.Exception is  {
               //中断异常提示
            }

        }

        /// <summary>
        /// 应用关闭
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
        }



        #region 父类抽象方法实现
        public override void BuildSteps()
        {
            var startupRoot = ConfigurationHelper.GetStartupConfigRoot();
            if (!startupRoot.IsNull())
            {
                //加载ResourceModules
                var resourcesTypes = startupRoot.GetAtrriuteValues("Type", new string[] { ConfigurationHelper.Config_Node_ResourceModules, ConfigurationHelper.Config_Node_Operation });
                var resourceModules = new List<IResourceModule>();
                foreach (var type in resourcesTypes)
                {
                    resourceModules.Add(CreateInstanceByType<IResourceModule>(type));
                }
                this.ThemeResourceModules.AddRange(resourceModules.Cast<IThemeResourceModule>());
                this.LanguageResourceMudules.AddRange(resourceModules.Cast<ILanguageResourceModule>());
                //加载LoginModules
                var loginTypes = startupRoot.GetAtrriuteValues("Type", new string[] { ConfigurationHelper.Config_Node_LoginModules, ConfigurationHelper.Config_Node_Operation });
                foreach (var type in loginTypes)
                {
                    this.LoginModules.Add(CreateInstanceByType<ILoginModule>(type));
                }
                //加载AuthenticationModules
                var authenticationTypes = startupRoot.GetAtrriuteValues("Type", new string[] { ConfigurationHelper.Config_Node_AuthenticationModules, ConfigurationHelper.Config_Node_Operation });
                foreach (var type in authenticationTypes)
                {
                    this.AuthenticationModules.Add(CreateInstanceByType<IAuthenticationModule>(type));
                }
                //加载AutorizationModules
                var authorizationTypes = startupRoot.GetAtrriuteValues("Type", new string[] { ConfigurationHelper.Config_Node_AuthorizationModules, ConfigurationHelper.Config_Node_Operation });
                foreach (var type in authenticationTypes)
                {
                    this.AuthorizationModules.Add(CreateInstanceByType<IAuthorizationModule>(type));
                }
                //加载执行流程
                var executionTypes = startupRoot.GetAtrriuteValues("Type", new string[] { ConfigurationHelper.Config_Node_ExecutionModules, ConfigurationHelper.Config_Node_Operation });
                foreach (var type in executionTypes)
                {
                    this.ExecutionModules.Add(CreateInstanceByType<IExecutionModule>(type));
                }
            }
        }

        protected override bool ExecuteThemeResourceModulesCore()
        {
            //加载主题资源
            foreach(var module in ThemeResourceModules)
            {
                if(!module.Loading(this, Context.CurrentTheme))
                {
                    throw new StartupException("Error occured when loading theme resource.");
                }
            }
            //主题资源加载完成
            foreach(var module in ThemeResourceModules)
            {
                if(!module.Loaded(this, Context.CurrentTheme))
                {
                    throw new StartupException("Error occured when loaded theme resource.");
                }
            }
            return true;
        }

        protected override bool ExecuteLanguageResourceModulesCore()
        {
            //加载语言资源
            foreach (var module in LanguageResourceMudules)
            {
                if (!module.Loading(this, Context.CurrentLanguage))
                {
                    throw new StartupException("Error occured when loading language resource.");
                }
            }
            //语言资源加载完成
            foreach (var module in LanguageResourceMudules)
            {
                if (!module.Loaded(this, Context.CurrentLanguage))
                {
                    throw new StartupException("Error occured when loaded language resource.");
                }
            }
            return true;
        }

        protected override bool ExecuteLoginModulesCore()
        {
            foreach(var login in LoginModules)
            {
                try
                {
                    login.Login(this);
                }
                catch(Exception ex)
                {
                    throw new StartupException("Error occured when loading login module.", ex);
                }
            }

            return true;
        }

        protected override bool ExecuteAutheticationModulesCore()
        {
            var result = true;
            var message = "Authenticating user is successed.";
            foreach(var auth in AuthenticationModules)
            {
                if (!auth.Authenticate(this))
                {
                    result = false;
                    message = "Invalid user, please check inputed user info!";
                    break;
                }
            }
            //用户认证失败
            if (!result)
            {
                foreach(var login in LoginModules)
                {
                    login.LoginFailed(this, message);
                }
            }
            //用户认证成功
            else
            {
                foreach (var login in LoginModules) {
                    login.LoginSuccessed(this, message);
                }
            }

            return result;
        }

        protected override bool ExecuteAuthorizationModulesCore()
        {
            //用户授权操作
            return true;
        }

        protected override bool ExecuteExecutionModulesCore()
        {
            //加载数据
            return true;
        }

        #endregion

        #region 私有方法
        private T CreateInstanceByType<T>(string typeInfo)
        {
            try
            {
                var array = typeInfo.Split(',');
                var instance = Assembly.LoadFrom(string.Format("{0}.dll", array[1])).CreateInstance(array[0]);
                return (T)instance;
            }
            catch(Exception ex)
            {
                throw new StartupException(ex);
            }
        }
      
        #endregion

    }
}
