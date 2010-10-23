using System.Net;
using EngageLib.Interfaces;

namespace EngageLib
{
    public class EngageApiSettings : IEngageApiSettings
    {
        private readonly string apiKey;
        private readonly string apiBaseUrl;
        private readonly IWebProxy webProxy;

        public EngageApiSettings(string apiBaseUrl, string apiKey) : this(apiBaseUrl, apiKey, null)
        {
        }

        public EngageApiSettings(string apiBaseUrl, string apiKey, IWebProxy webProxy)
        {
            this.apiBaseUrl = apiBaseUrl;
            this.apiKey = apiKey;
            this.webProxy = webProxy;
        }

        #region IEngageApiSettings Members

        public IWebProxy WebProxy
        {
            get { return webProxy; }
        }

        public string ApiKey
        {
            get { return apiKey; }
        }

        public string ApiBaseUrl
        {
            get { return apiBaseUrl; }
        }

        #endregion
    }
}