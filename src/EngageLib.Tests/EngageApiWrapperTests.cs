using NUnit.Framework;

namespace EngageLib.Tests
{
    public class EngageApiWrapperTests
    {
        [Test]
        public void ConstructorAppendsDirectorySeperatorIfNotExists()
        {
            var settings = new EngageApiSettings("http://abc.com", "");
            var api = new EngageApiWrapper(settings);
            Assert.AreEqual("http://abc.com/", api.BaseUrl);
        }

        [Test]
        public void ConstructorSetsApiKey()
        {
            var settings = new EngageApiSettings("http://abc.com/", "apikey");
            var api = new EngageApiWrapper(settings);
            Assert.AreEqual("apikey", api.ApiKey);
        }

        [Test]
        public void ConstructorSetsBaseUrl()
        {
            var settings = new EngageApiSettings("http://abc.com/", "");
            var api = new EngageApiWrapper(settings);
            Assert.AreEqual("http://abc.com/", api.BaseUrl);
        }
    }
}