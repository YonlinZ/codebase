using System;

namespace InstantMessagingModule
{
    public class MessageBasic
    {
        /// <summary>
        /// 消息命令
        /// </summary>
        public MessageType MessageType { get; set; } = MessageType.Common;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 发送Id
        /// </summary>
        public string SendId { get; set; }
        /// <summary>
        /// 接收Id，群讨论时 ReceiveId 为空字符串
        /// </summary>
        public string ReceiveId { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; } = DateTime.Now;
    }
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 通用消息
        /// </summary>
        Common,
        /// <summary>
        /// 命令型消息
        /// </summary>
        Command,
    }
}