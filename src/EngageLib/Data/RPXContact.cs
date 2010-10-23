using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EngageLib.Data
{
	public class EngageContact
	{
		public string DisplayName { get; private set; }
		public IEnumerable<EngageContactEmailAddress> EmailAddresses { get; private set; }

		public static EngageContact FromXElement(XElement xElement)
		{
			return new EngageContact
			       	{
			       		DisplayName = xElement.Element("displayName") == null
			       			? null
			       			: xElement.Element("displayName").Value,
						EmailAddresses = xElement.Element("emails") == null
							? new List<EngageContactEmailAddress>()
							: xElement
			       				.Element("emails")
			       				.Elements("email")
			       				.Select(email => EngageContactEmailAddress.FromXElement(email))
			       				.ToList()
			       	};
		}
	}
}