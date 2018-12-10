using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFPanel.Service.FileManager;

namespace XFPanel.Service.Logs
{
    /// <summary>
    /// 写入日志
    /// </summary>
    public class EditErrorLog
    {
        private string errorContent;
        public EditErrorLog(string error)
        {
            errorContent = error;
        }
        public void AddPend()
        {
            var logPath = WebPathService.ErrorLogPath + @"\" + DateTime.Now.Day;
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            FileInfo fileInfo = new FileInfo(logPath + @"\" + $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}-log.txt");
            FileStream fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(DateTime.Now);
            streamWriter.WriteLine("- - - - - - - - - - -");
            streamWriter.WriteLine(errorContent);
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
