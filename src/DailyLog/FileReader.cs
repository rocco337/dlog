using System;
using System.IO;

namespace DailyLog
{
    public class FileLineAppender
    {
        private readonly FileStream _fileStream;

        public FileLineAppender(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            _fileStream = System.IO.File.Open(filePath, FileMode.Append);
        }

        public void AppendLine(string message)
        {
            var logWriter = new System.IO.StreamWriter(_fileStream);
            logWriter.WriteLine(message);
            logWriter.Dispose();
        }
    }
}