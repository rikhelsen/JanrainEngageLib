using System.Xml.Linq;

namespace EngageLib.Data
{
    public class EngageAddress : EngageElementBase
    {
        public string Formatted
        {
            get { return GetPropertyValue("formatted"); }
        }

        public string StreetAddress
        {
            get { return GetPropertyValue("streetAddress"); }
        }

        public string Locality
        {
            get { return GetPropertyValue("locality"); }
        }

        public string Region
        {
            get { return GetPropertyValue("region"); }
        }

        public string PostalCode
        {
            get { return GetPropertyValue("postalCode"); }
        }

        public string Country
        {
            get { return GetPropertyValue("country"); }
        }

        public static EngageAddress FromXElement(XElement xElement)
        {
            var name = new EngageAddress();

            foreach (var element in xElement.Elements())
            {
                var elementLocalName = element.Name.LocalName;
                name.AddProperty(elementLocalName, element.Value);
            }

            return name;
        }
    }
}