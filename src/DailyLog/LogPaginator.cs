using System;

namespace DailyLog
{
    public class LogPaginator
    {
        private FileReader _fileReader;

        const int pageSize = 10;

        public LogPaginator(FileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void LoadNext(int pageIndex = 0)
        {
            var logs = this._fileReader.ReadLines(pageIndex, pageSize);

            //if there are no logs returned exit recursion
            if (logs.Length == 0) return;

            foreach (var log in logs)
                Console.WriteLine(log.TrimEnd().TrimEnd('-'));

            if (logs.Length < pageSize) return;

            Console.WriteLine("n for next page");
            var nextPage = Console.ReadLine() == "n";
            if (nextPage)
                this.LoadNext(++pageIndex);
        }
    }
}