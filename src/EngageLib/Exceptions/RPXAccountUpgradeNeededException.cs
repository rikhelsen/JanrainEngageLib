using System;

namespace EngageLib.Exceptions
{
	[Serializable]
	public class EngageAccountUpgradeNeededException : EngageResponseException
	{
		public EngageAccountUpgradeNeededException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public EngageAccountUpgradeNeededException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public EngageAccountUpgradeNeededException()
		{
		}
	}
}