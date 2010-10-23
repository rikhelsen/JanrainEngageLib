using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
	[TestFixture]
	public class EngageServiceContactsTests
	{
		#region Setup/Teardown

		[SetUp]
		public void TestSetup()
		{
			mockApiWrapper = MockRepository.GenerateMock<IEngageApiWrapper>();
			EngageService = new EngageService(mockApiWrapper);
		}

		#endregion

		private EngageService EngageService;
		private IEngageApiWrapper mockApiWrapper;

		[Test]
		public void GetContacts_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp",
			                                 new XElement("response",
			                                              new XElement("startIndex", 0),
			                                              new XElement("itemsPerPage", 0),
			                                              new XElement("totalResults", 0)
			                                 	)
				);

			mockApiWrapper.Expect(
				w => w.Call(
				     	Arg<string>.Matches(s => s.Equals("get_contacts")),
				     	Arg<IDictionary<string, string>>.Matches(
				     		d => d["identifier"].Equals("id")
				     		))).Return(emptyResponse);

			EngageService.GetContacts("id");

			mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetContacts_ThrowsOnEmptyIdentifier()
		{
			EngageService.GetContacts("");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetContacts_ThrowsOnNullIdentifier()
		{
			EngageService.GetContacts(null);
		}
	}
}