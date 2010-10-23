using System;
using System.Runtime.Serialization;

namespace EngageLib.Exceptions
{
	[Serializable]
	public abstract class EngageResponseException : EngageException
	{
		protected EngageResponseException()
		{
		}

		protected EngageResponseException(int errorCode, string message, Exception inner)
			: base(message, inner)
		{
			ErrorCode = errorCode;
		}

		protected EngageResponseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public int ErrorCode { get; set; }
	}
}