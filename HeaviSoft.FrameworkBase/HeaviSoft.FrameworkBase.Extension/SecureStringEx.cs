using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Extension
{
    public static class SecureStringEx
    {
        public static string GetOrginalString(this SecureString text) {
            if(text == null)
            {
                return null;
            }
            if(text.Length == 0)
            {
                return string.Empty;
            }
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(text);
            try
            {
                return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
}
