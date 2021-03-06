﻿using Sin.Net.Domain.Persistence.Adapter;
using System;

namespace Sin.Net.Domain.Infrastructure.Mqtt
{
    public delegate void MqttMessageReceivedEventHandler(object sender, MqttReceivedEventArgs e);

    public class MqttReceivedEventArgs : EventArgs
    {

        // -- Constructor

        public MqttReceivedEventArgs(string topic, string message)
        {
            Topic = topic;
            Message = message;
        }

        public T Deserialize<T>(Func<string, T> function) where T : new()
        {
            return function(Message);
        }

        public T Deserialize<T>(AdapterBase adapter) where T : new()
        {
            return adapter.Adapt<string, T>(Message);
        }

        // -- properties

        public string Topic { get; private set; }

        public string Message { get; private set; }

    }
}
