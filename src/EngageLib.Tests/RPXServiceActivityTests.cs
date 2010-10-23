using System;
using NUnit.Framework;
using Rhino.Mocks;
using EngageLib.Interfaces;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageServiceActivityTests
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

		//[Test]
		//public void AddActivity_CallsApiWrapperWithCorrectDetails()
		//{
		//    mockApiWrapper.Expect(
		//        w => w.Call(
		//                Arg<string>.Matches(s => s.Equals("activity")),
		//                Arg<IDictionary<string, string>>.Matches(
		//                    d => d["identifier"].Equals("id")
		//                    ))).Return(null);

		//    EngageService.AddActivity("id", null);

		//    mockApiWrapper.VerifyAllExpectations();
		//}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void AddActivity_ThrowsNotImplementedException()
		{
			EngageService.AddActivity("", null);
		}
    }
}