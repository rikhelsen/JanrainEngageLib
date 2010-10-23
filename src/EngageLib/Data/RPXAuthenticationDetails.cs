using System.Xml.Linq;

namespace EngageLib.Data
{
    public class EngageAuthenticationDetails : EngageElementBase
    {
        private EngageAddress address;
        private EngageName name;

        public EngageAddress Address
        {
            get { return address; }
        }

        public string Birthday
        {
            get { return GetPropertyValue("birthday"); }
        }

        public string DisplayName
        {
            get { return GetPropertyValue("displayName"); }
        }

        public string Email
        {
            get { return GetPropertyValue("email"); }
        }

        public string Gender
        {
            get { return GetPropertyValue("gender"); }
        }

        public string Identifier
        {
            get { return GetPropertyValue("identifier"); }
        }

        public string LocalKey
        {
            get { return GetPropertyValue("primaryKey"); }
        }

        public EngageName Name
        {
            get { return name; }
        }

        public string PhoneNumber
        {
            get { return GetPropertyValue("phoneNumber"); }
        }

        public string PhotoUrl
        {
            get { return GetPropertyValue("photo"); }
        }

        public string PreferredUsername
        {
            get { return GetPropertyValue("preferredUsername"); }
        }

    	public string ProviderName
    	{
    		get { return GetPropertyValue("providerName"); }
    	}

        public string Url
        {
            get { return GetPropertyValue("url"); }
        }

        public string UtcOffset
        {
            get { return GetPropertyValue("utcOffset"); }
        }

        public string VerifiedEmail
        {
            get { return GetPropertyValue("verifiedEmail"); }
        }

        private void AssignName(EngageName name)
        {
            this.name = name;
        }

        private void AssignAddress(EngageAddress address)
        {
            this.address = address;
        }

        public static EngageAuthenticationDetails FromXElement(XElement xElement)
        {
            var details = new EngageAuthenticationDetails();

            foreach (var element in xElement.Element("profile").Elements())
            {
                var elementLocalName = element.Name.LocalName;
                if (elementLocalName == "name")
                {
                    details.AssignName(EngageName.FromXElement(element));
                }
                else if (elementLocalName == "address")
                {
                    details.AssignAddress(EngageAddress.FromXElement(element));
                }
                else
                {
                    details.AddProperty(elementLocalName, element.Value);
                }
            }

			if(details.Name == null)
				details.AssignName(new EngageName());

			if(details.Address == null)
				details.AssignAddress(new EngageAddress());

            return details;
        }
    }
}