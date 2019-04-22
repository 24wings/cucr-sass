using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cucr.CucrSaas.Common.Util;

namespace Cucr.CucrSaas.App.Entity {
    /// <summary>
    /// 聊天室
    /// </summary>
    [Table ("oa_chat_room")]
    public class ChatRoom {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        [Key]
        public string id { get; set; } = Guid.NewGuid ().ToString ();
        /// <summary>
        /// 群聊名字
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public int inputTime { get; set; } = DateUtil.getNowSeconds ();
        /// <summary>
        /// 创建用户Id
        /// </summary>
        /// <value></value>
        public string userId { get; set; }
        /// <summary>
        /// 加入的用户Id集合
        /// </summary>
        /// <value></value>
        public string joinUserIds { get; set; }
        /// <summary>
        /// 加入的用户数量
        /// </summary>
        /// <value></value>
        public string joinUserNum { get; set; }
        /// <summary>
        /// 聊天室状态 0启用,1禁用
        /// </summary>
        /// <value></value>
        public ChatRoomStatus status { get; set; }
        /// <summary>
        /// 最后一条消息时间
        /// </summary>
        /// <value></value>
        public int lastMsgTime { get; set; }
        /// <summary>
        /// 最后一条消息类型
        /// </summary>
        /// <value></value>
        public MsgType lastMsgType { get; set; }
        /// <summary>
        /// 最后一条消息内容
        /// </summary>
        /// <value></value>
        public string lastMsgContent { get; set; }

    }
    /// <summary>
    /// 聊天室状态
    /// </summary>
    public enum ChatRoomStatus {
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
    public enum MsgType {
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 图片
        /// </summary>
        Image
    }
}