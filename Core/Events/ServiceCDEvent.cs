using Services.C.Core.Models;

namespace Services.C.Core.Events
{
    public class ServiceCDEvent : Event
    {
        public string Message { get; set; }
    }
}
