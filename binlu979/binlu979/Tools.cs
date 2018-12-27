using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace binlu979.Tools
{
    /// <summary>
    /// 常用工具类
    /// </summary>
    public  class Tools
    {
        #region 截取字符串
 
        /// <summary>
        /// 截取字符串。
        /// </summary>
        /// <param name="str">要接取得字符串</param>
        /// <param name="number">保留的字节数。按半角计算</param>
        /// <returns>指定长度的字符串</returns>
        public static string StringCal(string str, int number)
        {
            Byte[] tempStr = System.Text.Encoding.Default.GetBytes(str);
            if (tempStr.Length > number)
            {
                return System.Text.Encoding.Default.GetString(tempStr, 0, number - 2) + "..";
            }
            else
                return str;
        }


        #endregion
        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="FilePath">文件的物理地址</param>
        /// <returns></returns>
        public static bool DeleteFile(string FilePath)
        {
            try
            {
                System.IO.File.Delete(FilePath);
                return true;
            }
            catch
            {
                //errorMsg = "删除不成功！";
                return false;
            }
        }
        #endregion
        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            return IsNumeric(str);
        }
        #endregion
        #region 加密解密
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
     
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">要加密字符串</param>
        /// <param name="encryptKey">加密秘钥不设置将使用默认值</param>
        /// <returns></returns>

        public static string jiapass(string encryptString, string encryptKey="")
        {
            if (encryptKey == "")
            {
                encryptKey = "binlu979";
            }
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        ///   
        /// DES解密字符串          
        /// 待解密的字符串  
        /// 解密密钥,要求为8位,和加密密钥相同  
        /// 解密成功返回解密后的字符串，失败返源串  
        public static string jiepass(string decryptString, string decryptKey="")
        {
            if (decryptKey == "")
            {
                decryptKey = "binlu979";
            }
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
        #endregion

        #region 判断textbox输入是否是数字（正负，小数）
        /// <summary>
        /// 判断当前输入的是否是数字 e.Handled = true;即可
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool isNumbrFlaog(object sender ,KeyPressEventArgs e,numType em=numType.正负小数)
        {
            bool fh = true;
            TextBox tb = (TextBox)sender;
          //  e.Handled = true;
            //输入0-9和Backspace del 有效
            
            if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 8 || e.KeyChar == (char) ('-'))
            {
               
                fh= false;
            }
            else
            {
                if (em == numType.整数)
                {
                    return true;
                }
            }
             
            if (e.KeyChar == 46&&(em== numType.小数||em== numType.正负小数))                       //小数点      
            {
                if (tb.Text.Length< 1)
                {
                    fh = true;           //小数点不能在第一位   
                    return true;
                }  else
                {
                    float f;
                    if (float.TryParse(tb.Text + e.KeyChar.ToString(), out f))
                    {
                        fh = false;
                    }
                }
            }
            if (e.KeyChar == (char) ('-'))
            {
                if (em == numType.正负小数)
                {
                    if (tb.Text.Length > 1)
                    {
                        fh = true;
                    }
                }
                else
                {
                    fh = true;
                }
                
                    
            }
            
             
            return fh;
        }
        public enum numType
        {
            整数,小数,正负小数
        }
        #endregion
    }
}
