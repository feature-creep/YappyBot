using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using YappyBot.Lib;
using Xunit;

namespace YappyBot.Factory.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void Configure_Resolve_IClient_To_TwitchClient()
        {
            // Arrange
            var container = Container.Configure();
            IClient client; 

            using (var scope = container.BeginLifetimeScope())
            {
                // Act
                client = scope.Resolve<IClient>();
            }

            // Assert
            Assert.IsAssignableFrom<TwitchClient>(client);
        }
    }
}
