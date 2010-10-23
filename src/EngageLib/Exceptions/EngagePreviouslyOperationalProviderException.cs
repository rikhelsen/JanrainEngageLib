using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngagePreviouslyOperationalProviderException : EngageResponseException
	{
		public EngagePreviouslyOperationalProviderException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngagePreviouslyOperationalProviderException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngagePreviouslyOperationalProviderException()
		{
		}
	}
}