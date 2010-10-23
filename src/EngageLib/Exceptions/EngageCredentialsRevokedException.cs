using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageCredentialsRevokedException : EngageResponseException
	{
		public EngageCredentialsRevokedException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageCredentialsRevokedException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageCredentialsRevokedException()
		{
		}
	}
}