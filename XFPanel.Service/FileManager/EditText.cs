using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Model.Response;

namespace XFPanel.Service.FileManager
{
    /// <summary>
    /// 打开或编辑文本
    /// </summary>
    public class EditText
    {
        /// <summary>
        /// 以文本形式编辑文本
        /// 调用方法时，传入打开的编码，默认UTF8
        /// 以普通文本或二进制的形式打开文本
        /// 以普通文本或二进制的形式写入文本
        /// 代码
        /// utf8 65001
        /// gbk
        /// gb2312 936
        /// big5 950
        /// </summary>
        /// <returns></returns>

        private static string filePath;
        /// <summary>
        /// 打开或编辑文本
        /// </summary>
        /// <param name="sourcePath">文本路径</param>
        public EditText(string sourcePath)
        {
            filePath = sourcePath;
            Show();
        }
        //定义文件流
        private static FileInfo fileInfo;
        private static FileStream fileStream;
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;
        private static BinaryReader binaryReader;
        private static BinaryWriter binaryWriter;

        public void Show()
        {
            fileInfo = new FileInfo(filePath);
            fileStream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite);
            streamReader = new StreamReader(fileStream, Encoding.Default);
        }
        /// <summary>
        /// 以文本形式读写文件
        /// </summary>
        /// <param name="enCoding"></param>
        /// <returns></returns>
        public ResponseModel ReaderText(Encoding enCoding)//默认缓冲区大小4096
        {
            streamReader = new StreamReader(fileStream, enCoding);
            List<string> vs = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
                vs.Add(line);
            return new ResponseModel
            {
                Code = 200,
                Result = "读取成功",
                Data = vs
            };    //不能返回string，否则文本内容过长时会发生内存溢出
        }

        public ResponseModel WriterText(List<string> txt, Encoding enCoding)//默认缓冲区大小4096
        {
            fileStream = fileInfo.Open(FileMode.Truncate, FileAccess.Write);//清空内容
            fileStream.Close();

            fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(fileStream, enCoding);
            foreach (var c in txt)
                streamWriter.WriteLine(c);
            return new ResponseModel
            {
                Code = 200,
                Result = "写入成功"
            };
        }
        public ResponseModel ReaderTextClose()
        {
            try
            {
                streamReader.Close();
                fileStream.Close();
            }
            finally { }
            return new ResponseModel
            {
                Code = 200,
                Result = "关闭文件成功"
            };
        }
        public ResponseModel WriterTextClose()
        {
            try
            {
                streamWriter.Close();
                fileStream.Close();
            }
            finally { }
            return new ResponseModel
            {
                Code = 200,
                Result = "关闭文件成功"
            };
        }

        /// <summary>
        /// 二进制形式读写文本
        /// </summary>
        /// <returns></returns>
        public ResponseModel ReaderStream()//默认缓冲区大小4096
        {
            return new ResponseModel { };
        }

        public ResponseModel WriterStream()//默认缓冲区大小4096
        {
            return new ResponseModel { };
        }
    }
    }
