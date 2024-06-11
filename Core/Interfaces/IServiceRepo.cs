using Services.C.Core.Events;
using Services.C.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.C.Core.Interfaces
{
    public interface IServiceRepo
    {
        Task GetMessage(string message);
    }
}
