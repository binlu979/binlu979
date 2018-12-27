using System;
using System.Windows.Forms;

namespace binlu979.LogNet
{
    /// <summary>
    /// 默认方式的LOG记录如原生请 private ILogNet logNet = new LogNetSingle(Application.StartupPath + "\\Logs\\123.txt");
    /// </summary>
    public class Log
    {
        private ILogNet logNet = new LogNetSingle(Application.StartupPath + "\\Logs\\log.txt");
        public void clear()
        {
            System.IO.File.WriteAllBytes(Application.StartupPath + "\\Logs\\log.txt", new byte[0]);
           
        }
        /// <summary>
        /// 自定义的消息记录
        /// </summary>
        /// <param name="degree">消息等级</param>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
     public   void WriteMessage(HslMessageDegree degree, string keyWord, string text)
        {
            logNet.RecordMessage(  degree,   keyWord,   text);
        }

        /// <summary>
        /// 写入一条调试日志
        /// </summary>
        /// <param name="text">日志内容</param>
       public void WriteDebug(string text)
        {
            logNet.WriteDebug(text);
        }

        /// <summary>
        /// 写入一条调试日志
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
       public void WriteDebug(string keyWord, string text)
        {
            logNet.WriteDebug(keyWord, text);
        }

        /// <summary>
        /// 写入一条解释性的信息
        /// </summary>
        /// <param name="description"></param>
       public void WriteDescrition(string description)
        {
            logNet.WriteDescrition(description);
        }

        /// <summary>
        /// 写入一条错误日志
        /// </summary>
        /// <param name="text">日志内容</param>
       public void WriteError(string text)
        {
            logNet.WriteError(text);
        }

        /// <summary>
        /// 写入一条错误日志
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
      public  void WriteError(string keyWord, string text)
        {
            logNet.WriteError(keyWord, text);
        }

        /// <summary>
        /// 写入一条异常信息
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="ex">异常</param>
       public void WriteException(string keyWord, Exception ex)
        {
            logNet.WriteException(keyWord, ex);
        }

        /// <summary>
        /// 写入一条异常信息
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">内容</param>
        /// <param name="ex">异常</param>
       public void WriteException(string keyWord, string text, Exception ex)
        {
            logNet.WriteException(keyWord, text, ex);
        }

        /// <summary>
        /// 写入一条致命日志
        /// </summary>
        /// <param name="text">日志内容</param>
        public void WriteFatal(string text)
        {
            logNet.WriteFatal(text);
        }

        /// <summary>
        /// 写入一条致命日志
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
     public   void WriteFatal(string keyWord, string text)
        {
            logNet.WriteFatal(keyWord, text);
        }


        /// <summary>
        /// 写入一条信息日志
        /// </summary>
        /// <param name="text">日志内容</param>
       public void WriteInfo(string text)
        {
            logNet.WriteInfo(text);
        }

        /// <summary>
        /// 写入一条信息日志
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
     public   void WriteInfo(string keyWord, string text)
        {
            logNet.WriteInfo(keyWord, text);
        }

        /// <summary>
        /// 写入一行换行符
        /// </summary>
       public void WriteNewLine()
        {
            logNet.WriteNewLine();
        }

        /// <summary>
        /// 写入一条警告日志
        /// </summary>
        /// <param name="text">日志内容</param>
      public  void WriteWarn(string text)
        {
            logNet.WriteWarn(text);
        }

        /// <summary>
        /// 写入一条警告日志
        /// </summary>
        /// <param name="keyWord">关键字</param>
        /// <param name="text">日志内容</param>
       public void WriteWarn(string keyWord, string text)
        {
            logNet.WriteWarn(keyWord, text);
        }

    }
}
