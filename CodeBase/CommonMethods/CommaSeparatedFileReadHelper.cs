using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethods
{
    /// <summary>
    /// 逗号分割文件读取实体化
    /// </summary>
    public class CommaSeparatedFileReadHelper
    {
        /// <summary>
        /// 符号分割文件（类似CSV，ASC文件）读取实体化，并行
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="filePath">逗号分割文件路径</param>
        /// <param name="skipLineNum">需要跳过读取的行</param>
        /// <param name="linePreproccess">行值预处理</param>
        /// <param name="lineFilter">过滤行</param>
        /// <param name="valuePreproccess">对每一个值进行必要的格式化处理</param>
        /// <param name="encoding">读取文件时的编码</param>
        /// <param name="separator">分隔符</param>
        /// <param name="particularValuePro">特殊值处理，string是将值赋给的实体属性名，Func是处理方法</param>
        /// <exception cref="FileNotFoundException">路径文件不存在</exception>
        /// <returns></returns>
        public static IEnumerable<T> ReadParallel<T>(string filePath,
            int skipLineNum = 0,
            Func<string, string> linePreproccess = null,
            Func<string, bool> lineFilter = null,
            Func<string, string> valuePreproccess = null,
            Encoding encoding = null,
            char[] separator = null,
            params (string, Func<string, object>)[] particularValuePro) where T : class, new()
        {
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException($"File Not Found: {filePath}");
                var type = typeof(T);
                char[] seperator = new char[] { '\r', '\n', '\t' };
                var allData = string.Empty;
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (var sr = new StreamReader(stream, encoding ?? Encoding.GetEncoding("gb2312")))
                {
                    for (int i = 0; i < skipLineNum; i++)
                    {
                        sr.ReadLine();
                    }
                    allData = sr.ReadToEnd();
                }
                if (string.IsNullOrWhiteSpace(allData))
                {
                    return Enumerable.Empty<T>();
                }
                string[] records = allData.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                if (linePreproccess != null)
                {
                    var rangePartitioner1 = Partitioner.Create(0, records.Length);
                    Parallel.ForEach(rangePartitioner1, (range, loopState) =>
                    {
                        for (int i = range.Item1; i < range.Item2; i++)
                        {
                            records[i] = linePreproccess(records[i]);
                        }
                    });
                }
                if (lineFilter != null)
                {
                    // 对数据进行过滤
                    records = records.Where(lineFilter).ToArray();
                }
                var entityList = new T[records.Length];

                var rangePartitioner = Partitioner.Create(0, records.Length);
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        var attribute = (PropertyValueSettingAttribute)type.GetCustomAttribute(typeof(PropertyValueSettingAttribute));
                        var flag = attribute?.Flag;
                        var newEntity = Activator.CreateInstance(type);
                        var data = records[i].Split(separator ?? new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (valuePreproccess != null)
                        {
                            data = data.Select(valuePreproccess).ToArray();
                        }
                        var pro = type.GetProperties();
                        for (int j = 0; j < pro.Length && j < data.Length; j++)
                        {
                            object value = null;
                            if (particularValuePro != null)
                            {
                                foreach (var process in particularValuePro)
                                {
                                    if (process.Item1 == pro[j].Name)
                                    {
                                        value = process.Item2(data[j]);
                                        break;
                                    }
                                }
                            }
                            if (value == null)
                            {
                                value = data[j].ChangeType(pro[j].PropertyType);
                            }
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
                        entityList[i] = (T)newEntity;
                    }
                });
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
