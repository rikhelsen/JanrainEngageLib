using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageApplicationConfigurationException : EngageResponseException
	{
		public EngageApplicationConfigurationException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageApplicationConfigurationException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageApplicationConfigurationException()
		{
		}
	}
}