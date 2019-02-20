﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using YappyBot.Lib;

namespace YappyBot.Factory
{
    public static class Container
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TwitchClient>().As<IClient>();

            return builder.Build();
        }
    }
}
