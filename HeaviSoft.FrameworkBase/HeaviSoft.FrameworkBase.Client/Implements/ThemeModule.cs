using HeaviSoft.FrameworkBase.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeaviSoft.FrameworkBase.Core;
using System.Windows;

namespace HeaviSoft.FrameworkBase.Client.Implements
{
    public class ThemeModule : IThemeResourceModule
    {
        public bool Loaded(ExtendedApplicationBase app, string name)
        {
            return true;
        }

        public bool Loading(ExtendedApplicationBase app, string name)
        {
            ResourceDictionary resource = new ResourceDictionary() { Source = new Uri("pack://application:,,,/HeaviSoft.FrameworkBase.Theme;component/Themes/Generic.xaml") };
                //(ResourceDictionary)Application.LoadComponent(new Uri("pack://application:,,,/HeaviSoft.FrameworkBase.Theme;component/Themes/Generic.xaml"));
            app.Resources.MergedDictionaries.Add(resource);
            return true;
        }

        public bool UnLoaded(ExtendedApplicationBase app, string name)
        {
            throw new NotImplementedException();
        }

        public bool UnLoading(ExtendedApplicationBase app, string name)
        {
            throw new NotImplementedException();
        }
    }
}
