using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageUnsupportedProviderFeatureException : EngageResponseException
	{
		public EngageUnsupportedProviderFeatureException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageUnsupportedProviderFeatureException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageUnsupportedProviderFeatureException()
		{
		}
	}
}