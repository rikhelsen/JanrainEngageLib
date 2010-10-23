using System;
using System.Runtime.Serialization;

namespace EngageLib
{
	[Serializable]
	public class EngageException : ApplicationException
	{
		public EngageException()
		{
		}

		public EngageException(string message)
			: base(message)
		{
		}

		public EngageException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected EngageException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}