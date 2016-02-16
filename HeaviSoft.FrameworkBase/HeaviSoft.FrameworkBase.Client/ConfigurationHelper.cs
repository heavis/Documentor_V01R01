using HeaviSoft.FrameworkBase.Extension;
using HeaviSoft.FrameworkBase.Utility.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HeaviSoft.FrameworkBase.Client
{
    public class ConfigurationHelper
    {
        internal const string Config_File_Application = "Config/Application.xml";
        internal const string Config_File_Startup = "Config/Startup.xml";

        internal const string Config_Node_Modules = "Startup.Modules";
        internal const string Config_Node_ResourceModules = "ResourceModules";
        internal const string Config_Node_LoginModules = "LoginModules";
        internal const string Config_Node_AuthenticationModules = "AuthenticationModules";
        internal const string Config_Node_AuthorizationModules = "AuthorizationModules";
        internal const string Config_Node_ExecutionModules = "ExecutionModules";

        internal const string Config_Node_Operation = "Add";

        public static XElement GetApplicationConfigRoot()
        {
            return GetConfigRoot(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config_File_Application));
        }

        public static XElement GetStartupConfigRoot()
        {
            return GetConfigRoot(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config_File_Startup));
        }

        private static XElement GetConfigRoot(string filePath)
        {
            try
            {
                return XElement.Load(filePath);
            }
            catch (Exception ex)
            {
                //写日志
                Logger.Error("Error occured when loading xml file: " + filePath, ex);
                return null;
            }
        }
    }
}
