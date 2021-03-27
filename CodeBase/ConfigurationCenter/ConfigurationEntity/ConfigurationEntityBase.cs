using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigurationCenter.ConfigurationEntity
{
    /// <summary>
    /// 配置文件实体基类
    /// </summary>
    /// <typeparam name="T">配置文件实体</typeparam>
    public abstract class ConfigurationEntityBase<T> where T : ConfigurationEntityBase<T>, new()
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public static string ConfigPath;
        /// <summary>
        /// 获取配置文件实体
        /// </summary>
        public static T Instance { get; private set; } = (T)Activator.CreateInstance(typeof(T));
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public virtual bool LoadConfig()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ConfigPath) && !File.Exists(ConfigPath))
                {
                    return false;
                }

                string xml = File.ReadAllText(ConfigPath);
                XmlSerializer xmlSer = XmlSerializer.FromTypes(new[] { typeof(T) })[0];
                using (StringReader xmlReader = new StringReader(xml))
                {
                    var newInstance = (T)xmlSer.Deserialize(xmlReader);
                    var type = Instance.GetType();
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        propertyInfo.SetValue(Instance, propertyInfo.GetValue(newInstance));
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw new Exception("加载配置文件异常", ex);
            }
        }
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="path">位置文件路径</param>
        /// <returns></returns>
        public virtual bool LoadConfig(string path)
        {
            ConfigPath = path;
            return LoadConfig();
        }
        /// <summary>
        /// 保存xml
        /// </summary>
        public virtual void SaveConfig()
        {
            try
            {
                using (var writer = new StreamWriter(ConfigPath))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("保存xml异常", ex);
            }
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="newInstance"></param>
        public virtual void SetInstance(T newInstance)
        {
            var type = Instance.GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                propertyInfo.SetValue(Instance, propertyInfo.GetValue(newInstance));
            }
            SaveConfig();
        }
    }
}
