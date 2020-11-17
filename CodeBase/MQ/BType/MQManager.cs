using RabbitMQ.Client;
using System.Collections.Generic;
using System.Threading;

namespace InstantMessagingModule.BType
{
    /// <summary>
    /// MQ 连接信道管理
    /// </summary>
    public class MQManager
    {
        /// <summary>
        /// MQ Connection 缓存
        /// kye: 连接的Hash
        /// value： 连接
        /// </summary>
        public static Dictionary<int, IConnection> ConnCache { get; } = new Dictionary<int, IConnection>();
        /// <summary>
        /// MQ 信道缓存
        /// key: mq连接的Hash
        /// value：信道列表，一个mq连接多个信道
        /// </summary>
        public static Dictionary<int, List<IModel>> ChannelCache { get; } = new Dictionary<int, List<IModel>>();
        /// <summary>
        /// 线程控制信号量，同一时间只允许一个线程访问
        /// </summary>
        public static SemaphoreSlim SemaphoreSlim { get; } = new SemaphoreSlim(1);

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public static void CloseAllConnection()
        {
            SemaphoreSlim.Wait();
            foreach (var conn in ConnCache.Values)
            {
                conn.Dispose();
            }
            ConnCache.Clear();
            ChannelCache.Clear();
            SemaphoreSlim.Release();
        }
    }
}
