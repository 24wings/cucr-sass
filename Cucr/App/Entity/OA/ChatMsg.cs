using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cucr.CucrSaas.Common.Util;

namespace Cucr.CucrSaas.App.Entity {
    /// <summary>
    /// 聊天室
    /// </summary>
    [Table ("oa_chat_msg")]
    public class ChatMsg {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string content { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        /// <value></value>
        public int? sendTime { get; set; }
        /// <summary>
        /// 消息内容类型
        /// </summary>
        /// <value></value>
        public ContentType contentType { get; set; }
        /// <summary>
        /// 发送用户Id
        /// </summary>
        /// <value></value>
        public string sendUserId { get; set; }
        /// <summary>
        /// 消息来源
        /// </summary>
        /// <value></value>
        public MsgFrom msgFrom { get; set; } = MsgFrom.User;
        /// <summary>
        /// 状态
        /// </summary>
        /// <value></value>
        public MsgStatus status { get; set; } = MsgStatus.Active;

    }
    /// <summary>
    /// 聊天室状态
    /// </summary>
    public enum ContentType {
        /// <summary>
        /// 有效
        /// </summary>
        Active,
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled
    }
    /// <summary>
    /// 消息内容类型
    /// 0文本 1图片
    /// </summary>
    public enum MsgFrom {
        /// <summary>
        /// 文本
        /// </summary>
        User,
        /// <summary>
        /// 图片
        /// </summary>
        System
    }

    /// <summary>
    /// 消息状态
    /// </summary>

    public enum MsgStatus {
        /// <summary>
        /// 启用
        /// </summary>
        Active,
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled

    }
}