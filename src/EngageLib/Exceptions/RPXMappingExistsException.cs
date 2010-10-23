using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageMappingExistsException : EngageResponseException
	{
		public EngageMappingExistsException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageMappingExistsException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageMappingExistsException()
		{
		}
	}
}