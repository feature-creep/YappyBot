using System;
using System.Collections.Generic;
using System.Text;

namespace YappyBot.Lib
{
    public interface ITwitchClient : IClient
    {
        ClientLogger Logs { get; }
    }
}
