using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpByTopics.Async
{
    public class MultipleTaskDemo
    {
        List<string> _log;

        public void Run()
        {
            Task work1 = DoWork("Hard Work", 1000);
            Task work2 = DoWork("Easy Work", 100);
            Task work3 = DoWork("Super Hard Work", 10000);
            Task work4 = DoWork("Medium Work", 500);

            Task.WaitAll(new[] { work1, work2, work3, work4 });
;
            DisplayLog();
        }

        private async Task DoWork(string workName, int time)
        {
            _log.Add($"Before {workName}");

            // Anropa någon extern tjänst som tar tid på sig...
            await Task.Delay(time);

            _log.Add($"After {workName}");
        }

        //private void DoWork(string workName, int time)
        //{
        //    _log.Add($"Before {workName}");

        //    Thread.Sleep(time);

        //    _log.Add($"After {workName}");
        //}

        public MultipleTaskDemo()
        {
            _log = new List<string>();
        }

        private void DisplayLog()
        {
            foreach (var logItem in _log)
            {
                Console.WriteLine(logItem);
            }
        }
    }
}
