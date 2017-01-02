using System;

namespace DailyLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = (new FilePathEnviromentVariableSetter()).GetAndSetIfDoesntExists();

            var file = new FileReader(filePath);
            for (var ii = 0; ii < args.Length; ii++)
            {
                //message
                if (args[ii] == "-m")
                {
                    var message = args[++ii];
                    file.AppendLine($"{DateTime.Now} : {message}");
                    Console.WriteLine("Message logged!");
                }
            }
        }
    }
}
