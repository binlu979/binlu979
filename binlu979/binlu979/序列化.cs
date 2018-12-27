using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace binlu979.Tools
{
    /// <summary>
    /// 序列化和反序列化类前必须添加 [Serializable]
    /// </summary>
    public static class 序列化
    {
        #region 序列化
        /// <summary>
        /// 开始序列化
        /// </summary>
        /// <param name="cl">类</param>
        /// <param name="path">路径</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static bool onstart(object cl, string path, string name = "")
        {
            try
            {
                if (name != "")
                {
                    path = path + "/" + name;
                }
                Stream steam = File.Open(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(steam, cl);
                steam.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static object Deserialize(string path, string name = "")
        {
            try
            {
                if (name != "")
                {
                    path = path + "/" + name;
                }
                Stream steam2 = File.Open(@"D:\2\Programmers.dat", FileMode.Open);
                BinaryFormatter bf2 = new BinaryFormatter();
                object md2 = (object)bf2.Deserialize(steam2);//反序列化对象

                steam2.Close();
                return md2;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}

