using System.IO;
using NUnit.Framework;
using EngageLib.Exceptions;

namespace EngageLib.Tests
{
    [TestFixture]
    public class EngageApiResponseParserTests
    {
        [Test]
		[ExpectedException(typeof(EngageServiceTemporarilyUnavailableException), ExpectedMessage = "Service Temporarily Unavailable")]
		public void HandlesServiceTemporarilyUnavailableErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Service Temporarily Unavailable' code='-1'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageMissingParameterException), ExpectedMessage = "Missing parameter")]
		public void HandlesMissingParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing parameter' code='0'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageInvalidParameterException), ExpectedMessage = "Invalid parameter")]
		public void HandlesInvalidParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Invalid parameter' code='1'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

        [Test]
        [ExpectedException(typeof (EngageDataNotFoundException), ExpectedMessage = "Data not found")]
        public void HandlesDataNotFoundErrorCodeByThrowingException()
        {
            var errResponse =
                "<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Data not found' code='2'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
        }

		[Test]
		[ExpectedException(typeof(EngageTokenUrlMismatchException), ExpectedMessage = "Token URL mismatch: (your tokenUrl parameter) (original token URL)")]
		public void HandlesTokenUrlMismatchErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Token URL mismatch: (your tokenUrl parameter) (original token URL)' code='3'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageAuthenticationErrorException), ExpectedMessage = "Authentication error")]
		public void HandlesAuthenticationErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Authentication error' code='3'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageFacebookErrorException), ExpectedMessage = "Facebook Error")]
		public void HandlesFacebookErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Facebook Error' code='4'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageMappingExistsException), ExpectedMessage = "Mapping exists")]
		public void HandlesMappingExistsErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Mapping exists' code='5'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngagePreviouslyOperationalProviderException), ExpectedMessage = "Error interacting with a previously operational provider")]
		public void HandlesErrorInteractingWithAPreviouslyOperationProviderErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Error interacting with a previously operational provider' code='6'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageAccountUpgradeNeededException), ExpectedMessage = "Engage account upgrade needed to access this API")]
		public void HandlesEngageAccountUpgradeNeededToAccessThisAPIErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Engage account upgrade needed to access this API' code='7'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageCredentialsMissingException), ExpectedMessage = "Missing third-party credentials for this identifier")]
		public void HandlesMissingThirdPartyCredentialsForThisIdentifierErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing third-party credentials for this identifier' code='8'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageCredentialsRevokedException), ExpectedMessage = "Third-party credentials have been revoked")]
		public void HandlesThirdPartyCredentialsHaveBeenRevokedErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Third-party credentials have been revoked' code='9'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageApplicationConfigurationException), ExpectedMessage = "Your application is not properly configured")]
		public void HandlesYourApplicationIsNotProperlyConfiguredErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Your application is not properly configured' code='10'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageUnsupportedProviderFeatureException), ExpectedMessage = "The provider or identifier does not support this feature")]
		public void HandlesTheProviderOrIdentifierDoesNotSupportThisFeatureErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='The provider or identifier does not support this feature' code='11'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(EngageUnknownResponseException), ExpectedMessage = "Lorem Ipsum Dolor")]
		public void HandlesUnknownErrorCodesByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Lorem Ipsum Dolor' code='-999'/></rsp>";
            EngageApiResponseParser.Parse(errResponse);
		}

        [Test]
		[ExpectedException(typeof(EngageException))]
        public void ThrowsOnBlankInput()
        {
            EngageApiResponseParser.Parse("");
        }

        [Test]
        [ExpectedException(typeof (EngageException))]
        public void ThrowsOnNullReaderInput()
        {
            EngageApiResponseParser.Parse((TextReader)null);
        }

        [Test]
		[ExpectedException(typeof(EngageException))]
        public void ThrowsOnNullStringInput()
        {
            EngageApiResponseParser.Parse((string)null);
        }
    }
}