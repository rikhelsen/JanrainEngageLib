using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageServiceMappingTests
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
		public void GetAllMappings_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp",
			                                 new XElement("mappings",
			                                              new XElement("mapping",
			                                                           new XElement("primaryKey"),
			                                                           new XElement("identifiers")
			                                              	)
			                                 	)
				);

			mockApiWrapper.Expect(
				w => w.Call(
				     	Arg<string>.Matches(s => s.Equals("all_mappings")),
				     	Arg<IDictionary<string, string>>.Matches(
				     		d => d.Count == 0))).Return(emptyResponse);

			EngageService.GetAllMappings();

			mockApiWrapper.VerifyAllExpectations();
		}

        [Test]
        public void GetMappings_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("identifiers", new XElement("identifier")));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("mappings")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["primaryKey"].Equals("key")))).Return(emptyResponse);

            EngageService.GetAllMappings("key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetMappings_ThrowsOnEmptyLocalKey()
        {
            EngageService.GetAllMappings("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetMappings_ThrowsOnNullLocalKey()
        {
            EngageService.GetAllMappings(null);
        }

        [Test]
        public void MapLocalKey_CallsApiWrapperWithCorrectDetails()
        {
            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("map")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id") &&
                                  d["primaryKey"].Equals("key")))).Return(null);

            EngageService.MapLocalKey("id", "key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnEmptyIdentifier()
        {
            EngageService.MapLocalKey("", "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnEmptyLocalKey()
        {
            EngageService.MapLocalKey("id", "");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnNullIdentifier()
        {
            EngageService.MapLocalKey(null, "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnNullLocalKey()
        {
            EngageService.MapLocalKey("id", null);
        }

        [Test]
        public void UnmapLocalKey_CallsApiWrapperWithCorrectDetails()
        {
            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("unmap")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id") &&
                                  d["primaryKey"].Equals("key")))).Return(null);

            EngageService.UnmapLocalKey("id", "key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnEmptyIdentifier()
        {
            EngageService.UnmapLocalKey("", "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnEmptyLocalKey()
        {
            EngageService.UnmapLocalKey("id", "");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnNullIdentifier()
        {
            EngageService.UnmapLocalKey(null, "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnNullLocalKey()
        {
            EngageService.UnmapLocalKey("id", null);
        }
    }
}