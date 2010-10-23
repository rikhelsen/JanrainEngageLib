using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageLib.Data
{
	public class EngageGetContactsResponse : List<EngageContact>
	{
		public int ItemsPerPage { get; private set; }
		public int TotalResults { get; private set; }
		public int StartIndex { get; private set; }

		public static EngageGetContactsResponse FromXElement(XElement xElement)
		{
			var contacts = new EngageGetContactsResponse
			               	{
								ItemsPerPage = int.Parse(xElement.Element("response").Element("itemsPerPage").Value),
								TotalResults = int.Parse(xElement.Element("response").Element("totalResults").Value),
								StartIndex = int.Parse(xElement.Element("response").Element("startIndex").Value)
			               	};

			foreach(var contact in xElement.Element("response").Elements("entry"))
				contacts.Add(EngageContact.FromXElement(contact));

			return contacts;
		}
	}
}