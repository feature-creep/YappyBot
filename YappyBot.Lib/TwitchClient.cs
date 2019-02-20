using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib;
using Microsoft.Extensions.Configuration;
using TwitchLib.Client.Events;

namespace YappyBot.Lib
{
    public class TwitchClient : ITwitchClient
    {
        private readonly ConnectionCredentials _connectionCredentials;
        private readonly TwitchLib.Client.TwitchClient _client;
        private readonly IConfiguration _config;
        public ClientLogger Logs { get; private set; }

        public TwitchClient()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            _config = configurationBuilder.AddJsonFile("connection_credentials.json").Build();

            _connectionCredentials = new ConnectionCredentials(_config["Username"], _config["AccessToken"]);

            _client = new TwitchLib.Client.TwitchClient();
            _client.OnLog += ClientOnLog;
            _client.OnConnected += ClientOnConnected;

            Logs = new ClientLogger();
        }

        private void ClientOnLog(object sender, OnLogArgs e)
        {
            Logs.Enqueue(e.Data, e.DateTime);
        }

        private void ClientOnConnected(object sender, OnConnectedArgs e)
        {
            Logs.Enqueue($"The client is now connected to ${e.AutoJoinChannel}");
        }

        public void Connect()
        {
            _client.Initialize(_connectionCredentials, _config["Channel"]);
            _client.Connect();
            Logs.Enqueue($"The client is now starting to connect to #{_config["Channel"]}");
        }

        public void Connect(string channel)
        {
            _client.Initialize(_connectionCredentials, channel);
            _client.Connect();
            Logs.Enqueue($"The client is now starting to connect to #{channel}");
        }

        public void Disconnect()
        {
            // TODO: Make a class to save logs to a file on disconnect.
            // Every hour save logs to a new file and clear the ones in memory.
            _client.Disconnect();
        }

        public void Listen()
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
