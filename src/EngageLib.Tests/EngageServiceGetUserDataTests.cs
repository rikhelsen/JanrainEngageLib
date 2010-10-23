using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageServiceGetUserDataTests
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
        public void GetUserData_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("get_user_data")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id")))).Return(emptyResponse);

            EngageService.GetUserData("id");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
		public void GetUserData_ThrowsOnEmptyIdentifier()
        {
			EngageService.GetUserData("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetUserData_ThrowsOnNullIdentifier()
        {
			EngageService.GetUserData(null);
        }
    }
}