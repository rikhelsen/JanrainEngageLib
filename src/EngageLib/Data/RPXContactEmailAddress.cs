using System.Xml.Linq;

namespace EngageLib.Data
{
	public class EngageContactEmailAddress
	{
		public string Type { get; private set; }
		public string EmailAddress { get; private set; }

		public static EngageContactEmailAddress FromXElement(XElement xElement)
		{
			return new EngageContactEmailAddress
			       	{
			       		Type = xElement.Element("type") == null ? null : xElement.Element("type").Value,
						EmailAddress = xElement.Element("value") == null ? null : xElement.Element("value").Value
			       	};
		}
	}
}