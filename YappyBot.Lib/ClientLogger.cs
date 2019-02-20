using System;
using System.Collections.Generic;
using System.Text;

namespace YappyBot.Lib
{
    public class ClientLogger : ILogger
    {
        public Queue<KeyValuePair<string, DateTime>> Logs { get; set; }
        public delegate void ClientLoggerEnqueuedEventHandler(object sender, ClientLoggerEnqueuedEventArgs e);
        public event ClientLoggerEnqueuedEventHandler OnEnqueued;

        public ClientLogger()
        {
            Logs = new Queue<KeyValuePair<string, DateTime>>();
        }

        public void Enqueue(string log)
        {
            DateTime time = DateTime.Now;
            Logs.Enqueue(new KeyValuePair<string, DateTime>(log, time));
            OnEnqueued?.Invoke(this, new ClientLoggerEnqueuedEventArgs() { Log = log, TimeStamp = time });
        }

        public void Enqueue(string log, DateTime date)
        {
            Logs.Enqueue(new KeyValuePair<string, DateTime>(log, date));
            OnEnqueued?.Invoke(this, new ClientLoggerEnqueuedEventArgs() { Log = log, TimeStamp = date });
        }
    }

    public class ClientLoggerEnqueuedEventArgs : EventArgs
    {
        public string Log { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
