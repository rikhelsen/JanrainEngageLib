using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageServiceGetAuthenticationDetailsTests
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
        public void GetAuthenticationDetails_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("auth_info")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["token"].Equals("token")))).Return(emptyResponse);

            EngageService.GetAuthenticationDetails("token");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        public void GetAuthenticationDetails_Extended_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("auth_info")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["token"].Equals("token") &&
                                  d["extended"].Equals("true")))).Return(emptyResponse);

            EngageService.GetAuthenticationDetails("token", true);

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAuthenticationDetails_ThrowsOnEmptyToken()
        {
            EngageService.GetAuthenticationDetails("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthenticationDetails_ThrowsOnNullToken()
        {
            EngageService.GetAuthenticationDetails(null);
        }
    }
}