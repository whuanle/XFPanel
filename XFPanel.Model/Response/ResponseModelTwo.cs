using System;
using System.Collections.Generic;
using System.Text;

namespace XFPanel.Model.Response
{
    /// <summary>
    ///  消息响应
    /// </summary>
    public class ResponseModelTwo
    {
      /// <summary>
     /// 响应代码
     /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 响应结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 响应数据One
        /// </summary>
        public dynamic DataOne { get; set; }
        /// <summary>
        /// 响应数据Two
        /// </summary>
        public dynamic DataTwo { get; set; }
    }
}
