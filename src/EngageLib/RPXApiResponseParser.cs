using System.IO;
using System.Xml.Linq;
using EngageLib.Exceptions;

namespace EngageLib
{
	public static class EngageApiResponseParser
	{
		public static XElement Parse(TextReader responseReader)
		{
			if (responseReader == null)
				throw new EngageException("No response to parse");

		    var doc = XDocument.Load(responseReader, LoadOptions.None);
			if (doc.Root.Attribute("stat").Value == "ok")
				return doc.Root;

			var errCode = int.Parse(doc.Root.Element("err").Attribute("code").Value);
			var errMsg = doc.Root.Element("err").Attribute("msg").Value;

			switch (errCode)
			{
				case -1:
					throw new EngageServiceTemporarilyUnavailableException(errCode, errMsg);
				case 0:
					throw new EngageMissingParameterException(errCode, errMsg);
				case 1:
					throw new EngageInvalidParameterException(errCode, errMsg);
				case 2:
					throw new EngageDataNotFoundException(errCode, errMsg);
				case 3:
					if(errMsg.ToLowerInvariant().StartsWith("token url mismatch"))
						throw new EngageTokenUrlMismatchException(errCode, errMsg);
					throw new EngageAuthenticationErrorException(errCode, errMsg);
				case 4:
					throw new EngageFacebookErrorException(errCode, errMsg);
				case 5:
					throw new EngageMappingExistsException(errCode, errMsg);
				case 6:
					throw new EngagePreviouslyOperationalProviderException(errCode, errMsg);
				case 7:
					throw new EngageAccountUpgradeNeededException(errCode, errMsg);
				case 8:
					throw new EngageCredentialsMissingException(errCode, errMsg);
				case 9:
					throw new EngageCredentialsRevokedException(errCode, errMsg);
				case 10:
					throw new EngageApplicationConfigurationException(errCode, errMsg);
				case 11:
					throw new EngageUnsupportedProviderFeatureException(errCode, errMsg);
				default:
					throw new EngageUnknownResponseException(errCode, errMsg);
			}
		}

		public static XElement Parse(string responseString)
		{
			if (string.IsNullOrEmpty(responseString))
				throw new EngageException("No response to parse.");

			using (var stringReader = new StringReader(responseString))
			{
				return Parse(stringReader);
			}
		}
	}
}