using System;

namespace DailyLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = (new FilePathEnviromentVariableSetter()).GetAndSetIfDoesntExists();

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
                        new FileLineAppender(filePath).AppendLine(new MessageEntity(message, tags).ToString());
                        Console.WriteLine("Message logged!");
                    }
                }
                else if (args[ii] == "-f")
                {
                    var fileReader = new FileReader(filePath);

                    loadLastTenLogs(fileReader);
                }
            }
        }

        private static void loadLastTenLogs(FileReader fileReader, int pageIndex=0)
        {            
            const int numOfLines = 10;
            
            var logs = fileReader.ReadLines(pageIndex, numOfLines);
            
            //if there are no logs returned exit recursion
            if(logs.Length==0) return;

            foreach (var log in logs)
                Console.WriteLine(log.TrimEnd().TrimEnd('-'));
            
            if(logs.Length<numOfLines) return;
            
            Console.WriteLine("n for next page");
            var nextPage = Console.ReadLine() == "n";
            if(nextPage)
                loadLastTenLogs(fileReader,++pageIndex);
        }
    }


}
