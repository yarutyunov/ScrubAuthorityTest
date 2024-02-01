using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ProductMedia;

namespace TestProject1
{
    public class MediaTest : TestBase
    {
        private readonly MediaContentServiceClient _sut;

        public MediaTest()
        {
            _sut = new MediaContentServiceClient(new BasicHttpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    Security =
                    {
                        Mode = BasicHttpSecurityMode.Transport
                    }
                },
                new EndpointAddress(new Uri("https://promostandards.scrubauthority.com/api/media_content")));
        }

        [Fact]
        public async Task GetMedia_Should_NotBeNull()
        {
            var result = await _sut.getMediaContentAsync(new GetMediaContentRequest
            {
                wsVersion = "1.1.0",
                id = "esp",
                password = ServicePassword,
                mediaType = mediaTypeType.Image,
                productId = "ADR2600"
            });

            Assert.NotNull(result.GetMediaContentResponse);
        }
    }
}
