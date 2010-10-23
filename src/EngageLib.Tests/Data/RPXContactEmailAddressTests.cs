﻿using System.Xml.Linq;
using NUnit.Framework;
using EngageLib.Data;

namespace EngageLib.Tests.Data
{
	[TestFixture]
	public class EngageContactEmailAddressTests
	{
		[Test]
		public void GetFromXElement_ParsesContactEmailAddressCorrectly()
		{
			var xelement = new XElement("email",
					new XElement("type", "Email Type"),
					new XElement("value", "user@domain.com")
				);
			var emailAddress = EngageContactEmailAddress.FromXElement(xelement);

			Assert.AreEqual("Email Type", emailAddress.Type);
			Assert.AreEqual("user@domain.com", emailAddress.EmailAddress);
		}

		[Test]
		public void GetFromXElement_ParsesContactEmailAddressCorrectlyWithoutTypeElement()
		{
			var xelement = new XElement("email",
					new XElement("value", "user@domain.com")
				);
			var emailAddress = EngageContactEmailAddress.FromXElement(xelement);

			Assert.IsNull(emailAddress.Type);
			Assert.AreEqual("user@domain.com", emailAddress.EmailAddress);
		}

		[Test]
		public void GetFromXElement_ParsesContactEmailAddressCorrectlyWithoutValueElement()
		{
			var xelement = new XElement("email",
					new XElement("type", "Email Type")
				);
			var emailAddress = EngageContactEmailAddress.FromXElement(xelement);

			Assert.AreEqual("Email Type", emailAddress.Type);
			Assert.IsNull(emailAddress.EmailAddress);
		}
	}
}