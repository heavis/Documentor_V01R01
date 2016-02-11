using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Client
{
    /// <summary>
    /// 程序入口
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 应用程序入口方法，可接收命令行启动
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            AppManager mgr = new AppManager();
            mgr.Run(args);
        }
    }
}
