using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Model.Response;
using XFPanel.Service.Logs;

namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 查询目录所有内容
    /// 返回 string[] 或者 List<string>
    /// </summary>
    public class SelectAllList
    {
        public static string sourcePath;
        public SelectAllList(string sourceDirPath)
        {
            sourcePath = sourceDirPath;
        }

        /// <summary>
        ///获取目录的所有内容,不对目录、文件进行区分
        ///文件夹名+文件名
        ///返回目录名称
        /// </summary>
        public ResponseModel DirectoryList()
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                directoryInfo.GetFiles();

            }
            catch (Exception ex)
            {
                EditErrorLog editErrorLog = new EditErrorLog(ex.ToString());
                return new ResponseModel
                {
                    Code = 0,
                    Result = "无权打开此目录"
                };
            }
            var dirList = Directory.GetFileSystemEntries(sourcePath);

            if (dirList.Length == 0)
                return new ResponseModel
                {
                    Code = 0,
                    Result = "这是一个空目录",
                };

            List<string> listName = new List<string>();
            foreach (var i in dirList)
            {
                listName.Add(System.IO.Path.GetFileName(i));
            }

            return new ResponseModel
            {
                Code = 200,
                Result = "获取成功",
                Data = listName
            };
        }


        /// <summary>
        ///获取目录的所有内容，不对目录、文件进行区分
        ///绝对路径文件夹名+绝对路径文件名
        ///返回目录名称
        /// </summary>
        public ResponseModel DirectoryList_Path()
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModel
                {
                    Code = 0,
                    Result = "目录不存在"
                };
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                directoryInfo.GetFiles();

            }
            catch (Exception ex)
            {
                EditErrorLog editErrorLog = new EditErrorLog(ex.ToString());
                return new ResponseModel
                {
                    Code = 0,
                    Result = "无权打开此目录"
                };
            }
            var dirList = Directory.GetFileSystemEntries(sourcePath);

            if (dirList.Length == 0)
                return new ResponseModel
                {
                    Code = 0,
                    Result = "这是一个空目录",
                };

            return new ResponseModel
            {
                Code = 200,
                Result = "获取成功",
                Data = dirList
            };
        }


        /// <summary>
        ///获取目录的所有内容，对目录、文件进行区分
        ///文件夹名+文件名
        ///返回目录名称
        /// </summary>
        public ResponseModelTwo DirectoryListTwo()
        {

            if (!Directory.Exists(sourcePath))
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "目录不存在"
                };
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                directoryInfo.GetFiles();

            }
            catch (Exception ex)
            {
                EditErrorLog editErrorLog = new EditErrorLog(ex.ToString());
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "无权打开此目录"
                };
            }

            var dirList = Directory.GetDirectories(sourcePath);
            var fileList = Directory.GetFiles(sourcePath);

            if (dirList.Length == 0 && fileList.Length == 0)
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "这是一个空目录",
                };

            List<string> dirListName = new List<string>();
            List<string> fileListName = new List<string>();
            foreach (var i in dirList)
            {
                dirListName.Add(System.IO.Path.GetFileName(i));
            }
            foreach (var i in fileList)
            {
                fileListName.Add(System.IO.Path.GetFileName(i));
            }
            return new ResponseModelTwo
            {
                Code = 200,
                Result = "获取成功",
                DataOne = dirListName,
                DataTwo = fileListName
            };
        }
        /// <summary>
        ///获取目录的所有内容，对目录、文件进行区分
        ///绝对路径文件夹名+绝对路径文件名
        ///返回目录名称
        /// </summary>
        /// <returns></returns>
        public ResponseModelTwo DirectoryList_PathTwo()
        {
            if (!Directory.Exists(sourcePath))
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "目录不存在"
                };
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                directoryInfo.GetFiles();

            }
            catch (Exception ex)
            {
                EditErrorLog editErrorLog = new EditErrorLog(ex.ToString());
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "无权打开此目录"
                };
            }
            var dirList = Directory.GetDirectories(sourcePath);
            var fileList = Directory.GetFiles(sourcePath);

            if (dirList.Length == 0 && fileList.Length == 0)
                return new ResponseModelTwo
                {
                    Code = 0,
                    Result = "这是一个空目录",
                };

            return new ResponseModelTwo
            {
                Code = 200,
                Result = "获取成功",
                DataOne = dirList,
                DataTwo = fileList
            };
        }
    }
}

