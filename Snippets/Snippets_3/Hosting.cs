﻿namespace Snippets3
{
    using System;
    using NServiceBus;
    using NServiceBus.Unicast;
    using NServiceBus.Unicast.Config;

    public class Hosting
    {
        public void Simple()
        {
            #region SendOnly

            Configure configure = Configure.With();
            ConfigUnicastBus configUnicastBus = configure.UnicastBus();
            IBus bus = configUnicastBus.SendOnly();

            #endregion
        }

        public void Startup()
        {
            #region Hosting-Startup

            Configure configure = Configure.With();
            //Apply configuration
            ConfigUnicastBus configUnicastBus = configure.UnicastBus();
            IStartableBus startableBus = configUnicastBus.CreateBus();
            IBus bus = startableBus.Start();
            #endregion
        }

        public void Shutdown()
        {
            IBus bus = null;
            #region Hosting-Shutdown
            UnicastBus busImpl = (UnicastBus) bus;
            busImpl.Dispose();
            #endregion
        }

        #region Hosting-Static
        public static class EndpointInstance
        {
            public static IBus Endpoint { get; private set; }
            public static void SetInstance(IBus endpoint)
            {
                if (Endpoint != null)
                {
                    throw new Exception("Endpoint already set.");
                }
                Endpoint = endpoint;
            }
        }
        #endregion
    }
}