using System;
using System.Collections.Generic;
using System.Text;

namespace XFPanel.Model.Response
{
/// <summary>
///  消息响应
/// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// 响应代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 响应代码
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public dynamic Data { get; set; }
    }
}
