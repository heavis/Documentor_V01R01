using System;
using System.Security.Cryptography;
using System.Text;

namespace HeaviSoft.FrameworkBase.Utility
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class EncryptHelper
    {
        private static string _keyCode = "HeaviSoft.FrameworkBase.";

        private EncryptHelper()
        {
        }

        /// <summary>
        /// DES3加密，使用默认密钥
        /// </summary>
        /// <param name="data">加密字符串</param>
        /// <returns></returns>
        public static string DES3Encrypt(string data)
        {
            return DES3Encrypt(data, _keyCode);
        }

        /// <summary>
        /// DES3加密
        /// </summary>
        /// <param name="data">加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DES3Encrypt(string data, string key)
        {
            var desKey = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = Convert.FromBase64String(desKey);
            //DES.Mode = CipherMode.CBC;
            //DES.Padding = PaddingMode.PKCS7;
            DES.IV = Convert.FromBase64String("ld6Et92CmbQ=");


            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(data);

            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// DES3解密,使用默认密钥
        /// </summary>
        /// <param name="data">解密字符串</param>
        /// <returns></returns>
        public static string DES3Decrypt(string data)
        {
            return DES3Decrypt(data, _keyCode);
        }

        /// <summary>
        /// DES3解密
        /// </summary>
        /// <param name="data">解密字符串</param>
        /// <param name="key">密钥，必须和加密时密钥一直</param>
        /// <returns></returns>
        public static string DES3Decrypt(string data, string key)
        {
            var desKey = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = Convert.FromBase64String(desKey);
           // DES.Mode = CipherMode.CBC;
            //DES.Padding = PaddingMode.PKCS7;
            DES.IV = Convert.FromBase64String("ld6Et92CmbQ=");

            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(data);
                result = Encoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception e)
            {
            }

            return result;
        }
    }
}
