using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 获取默认设定的目录
    /// </summary>
    public static class WebPathService
    {
        /// <summary>
        /// XFPanel 安装目录
        /// </summary>
        public static string XFPanel { get; } = @"/var/XFPanel";
        /// <summary>
        /// XFPanel 实际运行目录
        /// </summary>
        public static string RootPath { get; } = @"/" + Directory.GetCurrentDirectory();
        /// <summary>
        /// 用户网站目录
        /// </summary>
        public static string WebRootPath { get; } = @"/var/XFWWW";
        /// <summary>
        /// 程序日志存放目录
        /// </summary>
        public static string LogPath { get; } = WebRootPath + @"/Log";
        /// <summary>
        /// 程序异常错误日志目录
        /// </summary>
        public static string ErrorLogPath { get; } = LogPath + @"/Error";
    }
}
