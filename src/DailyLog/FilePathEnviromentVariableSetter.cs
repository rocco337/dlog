using System;
using System.IO;

namespace DailyLog
{
    public class FilePathEnviromentVariableSetter
    {
        private const string VariableName = "dlog_filepath";

        public string GetAndSetIfDoesntExists()
        {
            var filePath = Environment.GetEnvironmentVariable(VariableName);
            if (!string.IsNullOrEmpty(filePath)) return filePath;
            
            
            Console.WriteLine("Path of log file:");
            filePath = Console.ReadLine();
                
            var file = new FileInfo(filePath);
            if (!file.Exists)
                throw new FileNotFoundException();

            Environment.SetEnvironmentVariable(VariableName, filePath);

            return filePath;
        }
            
    }
}