using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageLib.Data
{
	public class EngageAllIdentifiers : Dictionary<string, IEnumerable<string>>
	{
		public static EngageAllIdentifiers FromXElement(XElement xElement)
		{
			var allIdentifiers = new EngageAllIdentifiers();

			foreach(var setofIdentifiers in xElement.Element("mappings").Elements("mapping"))
				allIdentifiers.Add(setofIdentifiers.Element("primaryKey").Value, EngageIdentifiers.FromXElement(setofIdentifiers));
			
			return allIdentifiers;
		}
	}
}