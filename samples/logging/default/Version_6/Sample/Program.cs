﻿using System;
using NServiceBus;

class Program
{

    static void Main()
    {

        #region ConfigureLogging
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.Logging.Default");
        //Note that no config is required in version 5 and higher since logging is enabled by default
        #endregion
        busConfiguration.SendFailedMessagesTo("error");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            bus.SendLocal(new MyMessage());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}