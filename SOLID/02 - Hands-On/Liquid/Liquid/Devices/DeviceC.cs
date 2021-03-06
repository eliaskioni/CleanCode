﻿using Liquid.Models;

namespace Liquid.Devices
{
    internal class DeviceC
    {
        public DeviceState State { get; private set; }
        
        public void Connect()
        {
            State = DeviceState.Connected;
        }

        public void Disconnect()
        {
            State = DeviceState.Disconnected;
        }

        public bool Analyze(DataToAnalyze data)
        {
            return data.Something == "LIQUID";
        }
    }
}