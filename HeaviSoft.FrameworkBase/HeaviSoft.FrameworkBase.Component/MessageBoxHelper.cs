using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Component
{
    public static class MessageBoxHelper
    {
        public static void Info(string title, object content)
        {
            Show(title, content, MessageBoxButton.OK);
        }

        public static MessageBoxResult Question(string title, object content, MessageBoxButton button)
        {
            return Show(title, content, button);
        }

        private static MessageBoxResult Show(string title, object content, MessageBoxButton button)
        {
            CustomMessageBox msgBox = new CustomMessageBox(title, content, button);
            msgBox.Topmost = true;
            msgBox.WindowStyle = WindowStyle.None;
            msgBox.AllowsTransparency = true;
            msgBox.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            msgBox.Width = 400;
            msgBox.Height = 250;
            msgBox.Show();

            return msgBox.MessageBoxResult;
        }
    }
}
