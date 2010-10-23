using System.Net;

namespace EngageLib.Interfaces
{
    public interface IEngageApiSettings
    {
        string ApiKey { get; }
        string ApiBaseUrl { get; }
        IWebProxy WebProxy { get; }
    }
}