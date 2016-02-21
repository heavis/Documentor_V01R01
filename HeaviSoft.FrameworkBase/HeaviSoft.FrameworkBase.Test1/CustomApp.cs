using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Test1
{
    public class CustomApp : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            CustomApp app = new CustomApp();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.ShowDialog();
        }
    }
}
