using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonMethods
{
    /// <summary>
    /// 逗号分割文件读取实体化
    /// </summary>
    public class CommaSeparatedFileReadHelper
    {
        /// <summary>
        /// 逗号分割文件（类似CSV，ASC文件）读取实体化
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="filePath">逗号分割文件路径</param>
        /// <param name="skipLineNum">需要跳过读取的行</param>
        /// <param name="linePreproccess">行值预处理</param>
        /// <param name="lineFilter">过滤行</param>
        /// <param name="valuePreproccess">对值进行处理</param>
        /// <param name="encoding">读取文件时的编码</param>
        /// <returns></returns>
        public static List<T> CommaSeparatedFileRead<T>(string filePath,
            int skipLineNum,
            Func<string, string> linePreproccess = null,
            Func<string, bool> lineFilter = null,
            Func<string, string> valuePreproccess = null,
            Encoding encoding = null) where T : class, new()
        {
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException($"File Not Found: {filePath}");
                var type = typeof(T);
                char[] seperator = new char[] { '\r', '\n', '\t' };
                var entityList = new List<T>();
                var allData = string.Empty;
                using (var sr = new StreamReader(filePath, encoding ?? Encoding.GetEncoding("gb2312")))
                {
                    for (int i = 0; i < skipLineNum; i++)
                    {
                        sr.ReadLine();
                    }
                    allData = sr.ReadToEnd();
                }
                string[] records = allData.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                if (linePreproccess != null)
                {
                    records = records.Select(linePreproccess).ToArray();
                }
                if (lineFilter != null)
                {
                    // 对数据进行过滤
                    records = records.Where(lineFilter).ToArray();
                }
                for (int i = 0; i < records.Length; i++)
                {
                    var attribute = (PropertyValueSettingAttribute)type.GetCustomAttribute(typeof(PropertyValueSettingAttribute));
                    var flag = attribute?.Flag;
                    var newEntity = Activator.CreateInstance(type);
                    var data = records[i].Split(',');
                    if (valuePreproccess != null)
                    {
                        data = data.Select(valuePreproccess).ToArray();
                    }
                    var pro = type.GetProperties();
                    for (int j = 0; j < pro.Length; j++)
                    {
                        var value = data[j].ChangeType(pro[j].PropertyType);
                        if (flag is null)
                        {
                            pro[j].SetValue(newEntity, value);
                            continue;
                        }
                        var valueSettingFlagAtt = (ValueSettingFlagAttribute)pro[j].GetCustomAttribute(typeof(ValueSettingFlagAttribute));
                        if (flag == ValueSettingFlagEnum.Setting && valueSettingFlagAtt != null)
                        {
                            pro[j].SetValue(newEntity, value);
                        }
                        else if (flag == ValueSettingFlagEnum.Ignore && valueSettingFlagAtt == null)
                        {
                            pro[j].SetValue(newEntity, value);
                        }
                    }
                    entityList.Add((T)newEntity);
                }
                return entityList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    /// <summary>
    /// 标记类，再用 ValueSettingFlagAttribute 标记属性，被标记的属性设置值（Setting）或者不设置值（Ignore）
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class PropertyValueSettingAttribute : Attribute
    {
        public PropertyValueSettingAttribute(ValueSettingFlagEnum flag)
        {
            Flag = flag;
        }

        public ValueSettingFlagEnum Flag { get; }


    }
    public enum ValueSettingFlagEnum
    {
        /// <summary>
        /// 需要设置属性值
        /// </summary>
        Setting,
        /// <summary>
        /// 忽略属性值
        /// </summary>
        Ignore
    }
    /// <summary>
    /// 标记属性，被标记的属性设置值（Setting）或者不设置值（Ignore），配合 PropertyValueSettingAttribute 使用
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class ValueSettingFlagAttribute : Attribute
    {
    }
}
