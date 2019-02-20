using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using YappyBot.Lib;

namespace YappyBot.IoCC
{
    public static class Container
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TwitchClient>().AsSelf().As<ITwitchClient>();

            return builder.Build();
        }
    }
}
