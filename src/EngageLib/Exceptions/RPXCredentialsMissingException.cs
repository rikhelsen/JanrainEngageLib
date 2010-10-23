using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageCredentialsMissingException : EngageResponseException
	{
		public EngageCredentialsMissingException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageCredentialsMissingException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageCredentialsMissingException()
		{
		}
	}
}