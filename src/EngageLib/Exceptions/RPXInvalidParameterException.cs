using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageInvalidParameterException : EngageResponseException
	{
		public EngageInvalidParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageInvalidParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageInvalidParameterException()
		{
		}
	}
}