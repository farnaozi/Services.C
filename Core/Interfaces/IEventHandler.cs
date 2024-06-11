using Services.C.Core.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Services.C.Core.Interfaces
{
    public interface IEventHandler<in TEvent> : IEventHandler
         where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
