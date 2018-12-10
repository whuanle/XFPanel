using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XFPanel.Model.Response;

namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 提取字符串中的路径信息
    /// 把路径分割成各个目录
    /// </summary>
    public class PathExtract
    {
        /// <summary>
        /// 路径分级
        /// </summary>
        /// <param name="strPath">路径字符串</param>
        /// <returns>ResponseModel</returns>
        public ResponseModel PathRegular(string strPath)
        {
            string ex = @"[^\\//]+";  // 以 \ 或 / 截取
            MatchCollection matches = Regex.Matches(strPath, ex, RegexOptions.IgnoreCase);

            Dictionary<int, string> path = new Dictionary<int, string>();

            int i = 0;
            foreach (var NextMatch in matches)
            {
                path.Add(i, NextMatch.ToString());
                i++;
            }
            return new ResponseModel
            {
                Code = 200,
                Result = "目录分级成功",
                Data = path
            };

        }
    }
}
