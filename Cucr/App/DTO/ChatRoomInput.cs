namespace Cucr.CucrSaas.App.DTO {
    /// <summary>
    /// 创建聊天室
    /// </summary>
    public class CreateChatRoomInput {
        /// <summary>
        /// 勾选的组织架构Id集合,以;切割
        /// </summary>
        /// <value></value>
        public string companyFrameworkIds { get; set; }
        /// <summary>
        /// 聊天室名字
        /// </summary>
        /// <value></value>
        public string name { get; set; }
        /// <summary>
        /// 勾选的用户Id集合,以;切割
        /// </summary>
        /// <value></value>
        public string userIds { get; set; }
    }
    /// <summary>
    /// 列出聊天室
    /// </summary>
    public class ListChatRoomInput {
        /// <summary>
        /// 页面数量
        /// </summary>
        /// <value></value>
        public int page { get; set; } = 0;
        /// <summary>
        /// 分页数据数量
        /// </summary>
        /// <value></value>
        public int pageSize { get; set; } = 10;
    }

    /// <summary>
    /// 搜索聊天室
    /// </summary>
    public class SearchChatRoomInput {
        /// <summary>
        /// 关键字
        /// </summary>
        /// <value></value>
        public string keyword { get; set; }
    }
}