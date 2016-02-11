using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Extension;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Client
{
    /// <summary>
    /// 应用管理类
    /// </summary>
    internal class AppManager : WindowsFormsApplicationBase
    {
        private ExtendedApplicationBase _app;

        protected override bool OnStartup(StartupEventArgs e)
        {
            _app = new ExtendedApplication();
            ExtendedApplicationBase.Current = _app;
            _app.Run();
            return false;
        }

        /// <summary>
        /// 应用已存在，切换到启动的应用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e)
        {
            if (_app.IsNull())
            {
                return;
            }
            _app.Activate();

            base.OnStartupNextInstance(e);
        }
    }
}
