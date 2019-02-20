using System;
using YappyBot.Lib;
using YappyBot.Factory;
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
                var app = scope.Resolve<IClient>();
            }
        }
    }
}
