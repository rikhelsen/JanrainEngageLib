using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageUnknownResponseException : EngageResponseException
	{
		public EngageUnknownResponseException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageUnknownResponseException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageUnknownResponseException()
		{
		}
	}
}