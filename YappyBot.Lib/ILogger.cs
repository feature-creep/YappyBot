﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YappyBot.Lib
{
    public interface ILogger
    {
        Queue<KeyValuePair<string, DateTime>> Logs { get; }
    }
}