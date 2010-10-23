using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageServiceStatusTests
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
		public void UpdateStatus_CallsApiWrapperWithCorrectDetails()
		{
			mockApiWrapper.Expect(
				w => w.Call(
						Arg<string>.Matches(s => s.Equals("set_status")),
						Arg<IDictionary<string, string>>.Matches(
							d => d["identifier"].Equals("id") && d["status"].Equals("statusValue")
							))).Return(null);

			EngageService.UpdateStatus("id", "statusValue");

			mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyIdentifier()
		{
			EngageService.UpdateStatus("", "status");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetMappings_ThrowsOnNullIdentifier()
		{
			EngageService.UpdateStatus(null, "status");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyStatus()
		{
			EngageService.UpdateStatus("id", "");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetMappings_ThrowsOnNullStatus()
		{
			EngageService.UpdateStatus("id", null);
		}
    }
}