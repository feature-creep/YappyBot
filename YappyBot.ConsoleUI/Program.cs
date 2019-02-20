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
            var container = Container.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                IClient app = scope.Resolve<IClient>();
            }
        }
    }
}
