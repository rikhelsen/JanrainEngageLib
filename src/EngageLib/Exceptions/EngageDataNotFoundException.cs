using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageDataNotFoundException : EngageResponseException
	{
		public EngageDataNotFoundException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageDataNotFoundException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageDataNotFoundException()
		{
		}
	}
}