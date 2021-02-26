using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethods
{
    /// <summary>
    /// 通用扩展方法
    /// </summary>
    public static class CommonExtension
    {
        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="isMilliseconds">是否为毫秒</param>
        /// <returns></returns>
        public static DateTime StampToDatetime(this long timeStamp, bool isMilliseconds = false)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));//当地时区
            //返回转换后的日期
            if (isMilliseconds)
                return startTime.AddMilliseconds(timeStamp);
            else
                return startTime.AddSeconds(timeStamp);
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="isMilliseconds"></param>
        /// <returns></returns>
        public static DateTime StampToDatetime(this string timeStamp, bool isMilliseconds = false)
        {
            var time = long.Parse(timeStamp);
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));//当地时区
            //返回转换后的日期
            if (isMilliseconds)
                return startTime.AddMilliseconds(time);
            else
                return startTime.AddSeconds(time);
        }
        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isMilliseconds">是否为毫秒</param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime dt, bool isMilliseconds = false)
        {
            if (dt.Kind != DateTimeKind.Utc)
            {
                dt = dt.ToUniversalTime();
            }
            if (isMilliseconds)
            {
                return (dt.Ticks - 621355968000000000) / 10000;
            }
            return (dt.Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// 替换文件名不能出现的字符
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string MakeValidFileName(string text, string replacement = "_")
        {
            StringBuilder str = new StringBuilder();
            var invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
            foreach (var c in text)
            {
                if (invalidFileNameChars.Contains(c))
                {
                    str.Append(replacement ?? "");
                }
                else
                {
                    str.Append(c);
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 获取字符串的md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5(this string input)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("-", "");
        }
    }
}
