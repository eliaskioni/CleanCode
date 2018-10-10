﻿using System;
using Liquid.Models;

namespace Liquid.Devices.Logging
{
    internal class DeviceWriterConsoleLog : IDeviceWriter
    {
        private readonly IDeviceWriter device;

        public DeviceWriterConsoleLog(IDeviceWriter device)
        {
            this.device = device;
        }

        public bool Analyze(DataToAnalyze data)
        {
            Console.WriteLine("Analyzing data with device B");

            var success = device.Analyze(data);

            if (success)
            {
                Console.WriteLine("Yep, it really is: {0}", data.Something);
            }

            return success;
        }
    }
}