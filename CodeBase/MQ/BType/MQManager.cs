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
        /// mq client 缓存
        /// </summary>
        public static List<MQClientBase> ClientCache { get; } = new List<MQClientBase>();
        /// <summary>
        /// 线程控制信号量，同一时间只允许一个线程访问
        /// </summary>
        public static SemaphoreSlim SemaphoreSlim { get; } = new SemaphoreSlim(1);

        /// <summary>
        /// 关闭所有连接
        /// </summary>
        public static void CloseAllConnection()
        {
            try
            {
                var count = SemaphoreSlim.CurrentCount;
                if (count > 0)
                {
                    SemaphoreSlim.Release(count);
                }
                SemaphoreSlim.WaitAsync();
                foreach (var conn in ConnCache.Values)
                {
                    if (conn.IsOpen)
                    {
                        conn.Dispose();
                    }
                }
                ConnCache.Clear();
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }
    }
}
