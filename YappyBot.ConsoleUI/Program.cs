using System;
using YappyBot.Lib;
using YappyBot.IoCC;
using Autofac;

namespace YappyBot.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = Container.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                ITwitchClient app = scope.Resolve<TwitchClient>();
                app.Logs.OnEnqueued += LogsOnEnqueued;
                app.Connect();

                while (true)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        static void LogsOnEnqueued(object sender, ClientLoggerEnqueuedEventArgs e)
        {
            Console.WriteLine(e.TimeStamp + " --- " + e.Log);
        }
    }
}
