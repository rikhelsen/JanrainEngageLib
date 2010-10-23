using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageLib.Data
{
    public class EngageIdentifiers : List<string>
    {
        public static EngageIdentifiers FromXElement(XElement xElement)
        {
            var identifiers = new EngageIdentifiers();

            foreach (var element in xElement.Element("identifiers").Elements("identifier"))
                identifiers.Add(element.Value);

            return identifiers;
        }
    }
}