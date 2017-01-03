using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyLog
{
    public class FileReader{
         private IEnumerable<string> Lines{get;}

        public FileReader(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            this.Lines = System.IO.File.ReadAllLines(filePath).Reverse();
           
        }

        public string[] ReadLines(int pageIndex, int numOfLines){
           return Lines.Skip(pageIndex*numOfLines).Take(numOfLines).ToArray();
        }
    }
}
