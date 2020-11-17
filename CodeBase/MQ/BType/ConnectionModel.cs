namespace InstantMessagingModule.BType
{
    /// <summary>
    /// 连接实体
    /// </summary>
    public class ConnectionModel
    {
        /// <summary>
        /// MQ服务器地址
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// MQ 服务端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// MQ服务登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// MQ服务密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VirtualHost { get; set; } = "/";
        /// <summary>
        /// 获取Hash
        /// </summary>
        /// <returns></returns>
        public int GetHash()
        {
            var result = $"{HostName}^{Port}^{UserName}^{Password}^{VirtualHost}".GetHashCode();
            return result;
        }
    }
}
