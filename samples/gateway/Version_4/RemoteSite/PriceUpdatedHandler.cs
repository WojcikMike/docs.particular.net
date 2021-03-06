﻿using System;
using NServiceBus;
using Shared;

#region PriceUpdatedHandler
public class PriceUpdatedHandler : IHandleMessages<PriceUpdated>
{
    IBus bus;

    public PriceUpdatedHandler(IBus bus)
    {
        this.bus = bus;
    }

    public void Handle(PriceUpdated message)
    {
        string messageHeader = bus.GetMessageHeader(message, Headers.OriginatingSite);
        Console.WriteLine("Price update for product: {0} received. Going to reply over channel: {1}", message.ProductId, messageHeader);

        bus.Reply(new PriceUpdateAcknowledged
                  {
                      BranchOffice = "RemoteSite"
                  });
    }
}

#endregion