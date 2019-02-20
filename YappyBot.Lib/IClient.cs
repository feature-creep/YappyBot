using System;
using System.Collections.Generic;
using System.Text;


namespace YappyBot.Lib
{
    public interface IClient
    {
        void Connect();
        void Disconnect();
        void Send();
        void Listen();
    }
}
