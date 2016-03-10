using HeaviSoft.FrameworkBase.Core;
using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.Documentor.Presentation.Docking.Implements
{
    public class ExecutionModule : IExecutionModule
    {
        public void Execute(ExtendedApplicationBase app)
        {
            var mainWindow = new DockingMainWindow();
            app.MainWindow = mainWindow;
            mainWindow.ShowDialog();
            app.ExitEx();
        }
    }
}
