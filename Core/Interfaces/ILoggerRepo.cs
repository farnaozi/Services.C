using System;
using System.Threading.Tasks;

namespace Services.C.Core.Interfaces
{
    public interface ILoggerRepo
    {
        Task LogInfo(string message);
        Task LogError(string message);
        Task LogError(Exception exception);
    }
}
