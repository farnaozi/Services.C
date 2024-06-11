using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Services.C.Core.Models;
using Services.C.Core.Enums;

namespace Services.C.Core.Interfaces
{
    public interface IEventBus
    {
        void Publish<T>(T @event, ExchangeTypes exchangeType, bool createQueue = true) where T : Event;

        void Subscribe<T, TH>(ExchangeTypes exchangeType)
            where T : Event
            where TH : IEventHandler<T>;
    }
}
