using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageMissingParameterException : EngageResponseException
	{
		public EngageMissingParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageMissingParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageMissingParameterException()
		{
		}
	}
}