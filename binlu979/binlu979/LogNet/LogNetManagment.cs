using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace binlu979.LogNet
{
    /*************************************************************************************
     * 
     *    目标：
     *        1. 高性能的日志类
     *        2. 灵活的配置
     *        3. 日志分级
     *        4. 控制输出
     *        5. 方便筛选
     *        6. 方便的配置按小时，天，月，年记录
     * 
     * 
     * 
     *************************************************************************************/


    /// <summary>
    /// 日志类的管理器
    /// </summary>
    public class LogNetManagment
    {


        /// <summary>
        /// 存储文件的时候指示单文件存储
        /// </summary>
        internal const int LogSaveModeBySingleFile = 1;
        /// <summary>
        /// 存储文件的时候指示根据文件大小存储
        /// </summary>
        internal const int LogSaveModeByFileSize = 2;
        /// <summary>
        /// 存储文件的时候指示根据日志时间来存储
        /// </summary>
        internal const int LogSaveModeByDateTime = 3;
        

        /// <summary>
        /// 日志文件的头标志
        /// </summary>
        internal const string LogFileHeadString = "Logs_";
  
        public static string GetDegreeDescription(HslMessageDegree degree)
        {
            switch (degree)
            {
                case HslMessageDegree.DEBUG: return logoLanguage.LogNetDebug;
                case HslMessageDegree.INFO: return logoLanguage.LogNetInfo;
                case HslMessageDegree.WARN: return logoLanguage.LogNetWarn;
                case HslMessageDegree.ERROR: return logoLanguage.LogNetError;
                case HslMessageDegree.FATAL: return logoLanguage.LogNetFatal;
                case HslMessageDegree.None: return logoLanguage.LogNetAbandon;
                default: return logoLanguage.LogNetAbandon;
            }
        }


        /// <summary>
        /// 公开的一个静态变量，允许随意的设置
        /// </summary>
        public static ILogNet LogNet { get; set; }


        /// <summary>
        /// 通过异常文本格式化成字符串用于保存或发送
        /// </summary>
        /// <param name="text">文本消息</param>
        /// <param name="ex">异常</param>
        /// <returns>异常最终信息</returns>
        public static string GetSaveStringFromException(string text, Exception ex)
        {
            StringBuilder builder = new StringBuilder(text);

            if (ex != null)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    builder.Append(" : ");
                }

                try
                {
                    builder.Append(logoLanguage.ExceptionMessage );
                    builder.Append( ex.Message );
                    builder.Append( Environment.NewLine );
                    builder.Append(logoLanguage.ExceptionSourse );
                    builder.Append( ex.Source );
                    builder.Append( Environment.NewLine );
                    builder.Append(logoLanguage.ExceptionStackTrace );
                    builder.Append( ex.StackTrace );
                    builder.Append( Environment.NewLine );
                    builder.Append(logoLanguage.ExceptionType );
                    builder.Append( ex.GetType( ).ToString( ) );
                    builder.Append( Environment.NewLine );
                    builder.Append(logoLanguage.ExceptopnTargetSite );
                    builder.Append( ex.TargetSite?.ToString( ) );
                }
                catch
                {

                }
                builder.Append(Environment.NewLine);
                builder.Append("\u0002/=================================================[    Exception    ]================================================/");
            }

            return builder.ToString();
        }
    }



    public class logoLanguage
    {
        public static string LogNetDebug => "调试";
        public static string LogNetInfo => "信息";
        public static string LogNetWarn => "警告";
        public static string LogNetError => "错误";
        public static string LogNetFatal => "致命";
        public static string LogNetAbandon => "放弃";
        public static string LogNetAll => "全部";
        public static string ExceptionMessage => "错误信息：";
        public static string ExceptionSourse => "错误源：";
        public static string ExceptionType => "错误类型：";
        public static string ExceptionStackTrace => "错误堆栈：";
        public static string ExceptopnTargetSite => "错误方法：";
        public static string ExceprionCustomer => "用户自定义方法出错：";
        public static string SuccessText => "成功";
    }
}
