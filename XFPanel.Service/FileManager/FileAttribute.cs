using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Model.Response;

namespace XFPanel.Service.FileManager
{
    public class FileAttribute
    {
        /// <summary>
        /// 获取文件属性
        /// </summary>
        public class File_Attribute
        {
            /// <summary>
            /// 显示文件属性
            /// </summary>
            /// <returns></returns>

            private static string sourceFilePath;
            public File_Attribute(string filePath)
            {
                sourceFilePath = filePath;
                GetFile_Att(sourceFilePath);
            }
            //文件属性集合
            public static string FilePath { get; set; }//文件完整路径
            public static string FileName { get; set; }//获取文件名称
            public static string FileSize { get; set; }//文件大小
            public static string Md5 { get; set; }//md5值
            public static string CreationTime { get; set; }//创建时间
            public static string LastAccessTime { get; set; }//最后一次访问时间
            public static string LastWriteTime { get; set; }//最后一次修改时间
            public static string AuthString { get; set; }//文件属性
            public static int AuthCode { get; set; } //文件属性代码
            public static string AuthRemark { get; set; }//文件属性说明


            /// <summary>
            /// 为静态变量写入属性
            /// </summary>
            private void GetFile_Att(string sourceFilePath)
            {
                FileInfo file = new FileInfo(sourceFilePath);
                FilePath = sourceFilePath;
                FileName = file.Name;
                FileSize = CountSize(file.Length);
                Md5 = GetMD5HashFromFile(sourceFilePath);
                CreationTime = file.CreationTime.ToString();
                LastAccessTime = file.LastAccessTime.ToString();
                LastWriteTime = file.LastWriteTime.ToString();
                AuthString = file.Attributes.ToString();
                GetFileAuth(file.Attributes);
            }

            public ResponseModel Show()
            {
                ResponseModel responseModel = new ResponseModel { Code = 200, Result = "获取属性成功" };
                responseModel.Data = new Dictionary<string, string>();
                responseModel.Data.Add("文件路径", FilePath);
                responseModel.Data.Add("文件名称", FileName);
                responseModel.Data.Add("文件大小", FileSize);
                responseModel.Data.Add("MD5值", Md5);
                responseModel.Data.Add("创建时间", CreationTime);
                responseModel.Data.Add("最后访问时间", LastAccessTime);
                responseModel.Data.Add("最近一次编辑时间", LastWriteTime);
                responseModel.Data.Add("文件属性", AuthString);
                responseModel.Data.Add("属性代码", AuthCode.ToString());
                responseModel.Data.Add("属性说明", AuthRemark);
                return responseModel;

            }
            /// <summary>
            /// 显示丰富的文件属性
            /// </summary>
            /// <returns></returns>
            public ResponseModel More(string sourceFilePath)
            {
                return new ResponseModel { };
            }
            /// <summary>
            /// 计算文件大小函数(保留两位小数),Size为字节大小
            /// </summary>
            /// <param name="Size">初始文件大小</param>
            /// <returns></returns>
            private static string CountSize(long Size)
            {
                string m_strSize = "";
                long FactSize = 0;
                FactSize = Size;
                if (FactSize < 1024.00)
                    m_strSize = FactSize.ToString("F2") + " Byte";
                else if (FactSize >= 1024.00 && FactSize < 1048576)
                    m_strSize = (FactSize / 1024.00).ToString("F2") + " K";
                else if (FactSize >= 1048576 && FactSize < 1073741824)
                    m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " M";
                else if (FactSize >= 1073741824)
                    m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " G";
                return m_strSize;
            }
            /// <summary>
            /// 获取文件md5值
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            private static string GetMD5HashFromFile(string fileName)
            {
                try
                {
                    FileStream file = new FileStream(fileName, FileMode.Open);
                    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(file);
                    file.Close();

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++)
                    {
                        sb.Append(retVal[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
                }
            }
            /// <summary>
            /// 获取文件详细属性
            /// </summary>
            private void GetFileAuth(FileAttributes fileAttributes)
            {
                switch (fileAttributes)
                {
                    case FileAttributes.Archive:
                        {
                            AuthCode = 32;
                            AuthRemark = "存档或备份文件";
                        }; break;
                    case FileAttributes.Compressed:
                        {
                            AuthCode = 2048;
                            AuthRemark = "压缩文件";
                        }; break;
                    case FileAttributes.Device:
                        {
                            AuthCode = 64;
                            AuthRemark = "保留供将来使用";
                        }; break;
                    case FileAttributes.Directory:
                        {
                            AuthCode = 16;
                            AuthRemark = "此文件是一个目录";
                        }; break;
                    case FileAttributes.Encrypted:
                        {
                            AuthCode = 16384;
                            AuthRemark = "此文件或目录已加密";
                        }; break;
                    case FileAttributes.Hidden:
                        {
                            AuthCode = 2;
                            AuthRemark = "隐藏文件";
                        }; break;
                    case FileAttributes.IntegrityStream:
                        {
                            AuthCode = 32768;
                            AuthRemark = "文件或目录包括完整性支持数据";

                        }; break;
                    case FileAttributes.Normal:
                        {
                            AuthCode = 128;
                            AuthRemark = "没有特殊属性的标准文件";
                        }; break;
                    case FileAttributes.NoScrubData:
                        {
                            AuthCode = 131072;
                            AuthRemark = "文件或目录从完整性扫描数据中排除";
                        }; break;
                    case FileAttributes.NotContentIndexed:
                        {
                            AuthCode = 8192;
                            AuthRemark = "索引文件";
                        }; break;
                    case FileAttributes.Offline:
                        {
                            AuthCode = 4096;
                            AuthRemark = "脱机文件";
                        }; break;
                    case FileAttributes.ReadOnly:
                        {
                            AuthCode = 1;
                            AuthRemark = "只读文件";
                        }; break;
                    case FileAttributes.ReparsePoint:
                        {
                            AuthCode = 1024;
                            AuthRemark = "超链接或快捷方式";
                        }; break;
                    case FileAttributes.SparseFile:
                        {
                            AuthCode = 512;
                            AuthRemark = "稀疏文件";
                        }; break;
                    case FileAttributes.System:
                        {
                            AuthCode = 4;
                            AuthRemark = "系统文件";
                        }; break;
                    case FileAttributes.Temporary:
                        {
                            AuthCode = 256;
                            AuthRemark = "临时文件";
                        }; break;
                }

            }
            /*
             * 
             * FileAttributes.
             常数    值   描述
            Normal	0	普通文件。没有设置任何属性。
            ReadOnly	1	只读文件。可读写。
            Hidden	2	隐藏文件。可读写。
            System	4	系统文件。可读写。
            Directory	16	文件夹或目录。只读。
            Archive	32	上次备份后已更改的文件。可读写。
            Alias	1024	链接或快捷方式。只读。
            Compressed	2048	压缩文件。只读。
            https://docs.microsoft.com/zh-cn/dotnet/api/system.io.fileattributes?redirectedfrom=MSDN&view=netframework-4.7.2
            https://blog.csdn.net/duguyiran_z/article/details/7998878
             */

        }
    }
}
