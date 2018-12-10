using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Model.Response;

namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 列出文件列表
    /// 返回 string[] 或者 List<string>
    /// </summary>
    public class SelectFilesList
    {
        private readonly string sourcePath;
        /// <summary>
        /// 列出文件列表
        /// </summary>
        /// <param name="sourceFilePath">文件路径</param>
        public SelectFilesList(string sourceFilePath)
        {
            sourcePath = sourceFilePath;
        }
        /// <summary>
        /// 查询目录下的文件列表
        /// 形式为 {Path}/{FileName}
        /// </summary>
        /// <returns>含绝对路径的 ResponseModel</returns>
        public ResponseModel FileList_Absolute()
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };

            var fileList = Directory.GetFiles(sourcePath);
            if (fileList.Length == 0)
                return new ResponseModel
                {
                    Code = 0,
                    Result = "文件为空"
                };
            return new ResponseModel
            {
                Code = 200,
                Result = "获取文件列表成功",
                Data = fileList
            };
        }
        /// <summary>
        /// 查询目录下的文件列表
        /// 形式为 {FileName}
        /// </summary>
        /// <returns>只含文件名的 ResponseModel</returns>
        public ResponseModel FileLis_Relative() 
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };

            var fileList = Directory.GetFiles(sourcePath);
            if (fileList.Length == 0)
                return new ResponseModel
                {
                    Code = 0,
                    Result = "文件为空"
                };

            List<string> listName = new List<string>();
            foreach (var i in fileList)
            {
                listName.Add(System.IO.Path.GetFileName(i));
            }
            return new ResponseModel
            {
                Code = 200,
                Result = "获取文件列表成功",
                Data = listName
            };
        }
    }
}