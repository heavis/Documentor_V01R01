using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeaviSoft.UIDesign
{
    public static class  MessageBoxHelper
    {
        public static MessageBoxButton Show(string title, object content)
        {
            return Show(title, content, MessageBoxButton.OK);
        }

        public static MessageBoxButton Show(string title, object content, MessageBoxButton button)
        {
            CustomMessageBox msgBox = new CustomMessageBox(title, content, button);
            msgBox.Topmost = true;
            msgBox.Show();

            return MessageBoxButton.OK;
        }
    }
}
