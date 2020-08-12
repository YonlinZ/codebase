using ConfigurationCenter.ConfigurationEntity;
using System.IO;
using System.Threading.Tasks;

namespace ConfigurationCenter
{
    /// <summary>
    /// 配置文件引擎
    /// </summary>
    public class ConfigurationEngine
    {
        /// <summary>
        /// 雨滴谱配置文件
        /// </summary>
        public static SomeEtt SomeEtt => SomeEtt.Instance;
        
        /// <summary>
        /// 初始化引擎，加载所有配置文件
        /// </summary>
        /// <returns></returns>
        public static async Task InitializeEngine()
        {
            await Task.Run(() =>
            {
                var path = Path.GetFullPath(@"");
                SomeEtt.ConfigPath = path;
                SomeEtt.LoadConfig();
            });
        }
    }
}
