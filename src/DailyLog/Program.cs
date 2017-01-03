using System;

namespace DailyLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = (new FilePathEnviromentVariableSetter()).GetAndSetIfDoesntExists();

            var file = new FileLineAppender(filePath);
            for (var ii = 0; ii < args.Length; ii++)
            {
                //message
                if (args[ii] == "-m")
                {
                    var message = args[++ii];

                    //check if there is list of tags for message
                    string[] tags = null;
                    if (args.Length - 1 > ii)
                        tags = args[++ii] != null ? args[ii].Split(',') : null;
                        
                    if (!string.IsNullOrEmpty(message))
                    {
                        file.AppendLine(new MessageEntity(message, tags).ToString());
                        Console.WriteLine("Message logged!");
                    }
                }
            }
        }
    }

   
}
