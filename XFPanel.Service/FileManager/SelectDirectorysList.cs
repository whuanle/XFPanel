using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Model.Response;

namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 查询目录列表(不含文件)
    /// 返回 string[] 或者 List<string>
    /// </summary>
    public class SelectDirectorysList
    {
        public static string sourcePath;
        /// <summary>
        /// 查询目录列表(不含1文件)
        /// </summary>
        /// <param name="sourceFilePath"></param>
        public SelectDirectorysList(string sourceFilePath)
        {
            sourcePath = sourceFilePath;
        }
        /// <summary>
        /// 形式为 {Path}/{DirectoryName}
        /// </summary>
        /// <returns>含绝对路径的 ResponseModel</returns>
        public ResponseModel DirList_Absolute()  
        {

            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };

            var dirList = Directory.GetDirectories(sourcePath);
            if (dirList.Length == 0)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Result = "该目录下没有子目录"
                };
            }
            return new ResponseModel
            {
                Code = 200,
                Result = "获取文件列表成功",
                Data = dirList
            };
        }
        /// <summary>
        /// 形式为 {DirectoryName}
        /// </summary>
        /// <returns>只含有目录名的 ResponseModel</returns>
        public ResponseModel DirLis_Relative() 
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };

            var dirList = Directory.GetDirectories(sourcePath);
            if (dirList.Length == 0)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Result = "该目录下没有子目录"
                };
            }
            List<string> listName = new List<string>();
            foreach (var i in dirList)
            {
                listName.Add(System.IO.Path.GetFileName(i));
            }
            return new ResponseModel
            {
                Code = 200,
                Result = "获取文件列表成功",
                Data = dirList
            };
        }
    }
}
