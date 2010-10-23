using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageFacebookErrorException : EngageResponseException
	{
		public EngageFacebookErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageFacebookErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageFacebookErrorException()
		{
		}
	}
}