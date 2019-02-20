using System;
using System.Collections.Generic;
using System.Text;

namespace YappyBot.Lib
{
    public interface ILogger
    {
        List<string> Logs { get; }
    }
}