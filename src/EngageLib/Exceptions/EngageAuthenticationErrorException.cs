using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageAuthenticationErrorException : EngageResponseException
	{
		public EngageAuthenticationErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageAuthenticationErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageAuthenticationErrorException()
		{
		}
	}
}