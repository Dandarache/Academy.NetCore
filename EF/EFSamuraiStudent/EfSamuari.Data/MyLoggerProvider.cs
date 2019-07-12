using Microsoft.Extensions.Logging;
using System;

namespace EfSamurai.Data
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public EventHandler<string> CommandExecuted;

        public ILogger CreateLogger(string categoryName)
        {
            MyLogger _mylogger = new MyLogger();
            _mylogger.CommandExecuted += Aaa;     
            return _mylogger;
        }

        private void Aaa(object sender, string message)
        {
            CommandExecuted?.Invoke(sender, message);
        }

        public void Dispose()
        {
        }

        private class MyLogger : ILogger
        {

            public EventHandler<string> CommandExecuted;

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
              Func<TState, Exception, string> formatter)
            {
                if (eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")
                {
                    string formatted = formatter(state, exception);

                    CommandExecuted?.Invoke(this, formatted);

                    //Console.WriteLine("---------------------------------------------------------------------");
                    //Console.WriteLine();
                    //Console.WriteLine($"EventName: {eventId.Name}");
                    //Console.WriteLine($"EventId: {eventId.Id} ");

                    //Console.WriteLine();

                    //Console.WriteLine(formatted);
                    //Console.WriteLine();
                    //Console.WriteLine();
                    //Console.WriteLine();
                }
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}
