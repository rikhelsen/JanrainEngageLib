using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageTokenUrlMismatchException : EngageAuthenticationErrorException
	{
		public EngageTokenUrlMismatchException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageTokenUrlMismatchException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageTokenUrlMismatchException()
		{
		}
	}
}