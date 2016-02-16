using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;

namespace HeaviSoft.Documentor.Presentation.Login.Implements
{
    public class ExecutionModule : IExecutionModule
    {
        public void Execute(ExtendedApplicationBase app)
        {
            MainWindow mainWindow = new MainWindow();
            app.MainWindow = mainWindow;
            mainWindow.ShowDialog();
            app.ExitEx();
        }
    }
}
