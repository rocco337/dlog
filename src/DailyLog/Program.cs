﻿using System;
using System.Text;

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
                    var paginator = new LogPaginator(fileReader);
                    paginator.LoadNext();
                }
                else if (args[ii] == "-h")
                {
                    var helpText = new StringBuilder();

                    helpText.AppendLine("     _ _");
                    helpText.AppendLine("    | | |");
                    helpText.AppendLine("  _ | | |      ___   ____");
                    helpText.AppendLine(@" / || | |     / _ \ / _  |");
                    helpText.AppendLine(" (_| | |____| |_| ( ( | |");
                    helpText.AppendLine(@" \____|_______)___/ \_|| |");
                    helpText.AppendLine("                   (_____|");
                    helpText.AppendLine("");
                    helpText.AppendLine("Log your daily thought using dLog. By specifying path to the file dLog is logging message to file. If file is on file sharing service like DropBox, you can use dLog on multiple devices.");
                    helpText.AppendLine("-m \"simple message\"");                    
                    helpText.AppendLine("-m \"message wth tags\" tag1,tag2,tag3");
                    helpText.AppendLine("-f \"load last messages\"");
                    
                    Console.Write(helpText.ToString());
                }
            }
        }

        
    }


}
