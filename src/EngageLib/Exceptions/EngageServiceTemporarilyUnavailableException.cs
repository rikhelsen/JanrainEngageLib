using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageServiceTemporarilyUnavailableException : EngageResponseException
	{
		public EngageServiceTemporarilyUnavailableException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageServiceTemporarilyUnavailableException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageServiceTemporarilyUnavailableException()
		{
		}
	}
}