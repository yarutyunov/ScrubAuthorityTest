using System.ServiceModel;
using Ppc;

namespace TestProject1;

public class PpcTest
{
    [Fact]
    public async Task FobPointArray_Should_NotBeNull()
    {
        var sut = new PricingAndConfigurationServiceClient(new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            },
            new EndpointAddress(new Uri("https://promostandards.scrubauthority.com/api/ppc")));

        var result = await sut.getFobPointsAsync(new GetFobPointsRequest
        {
            wsVersion = "1.0.0",
            id = "esp",
            password = "",
            localizationCountry = "US",
            localizationLanguage = "en",
            productId = "KOI763"
        });

        Assert.NotNull(result.GetFobPointsResponse);
    }
}