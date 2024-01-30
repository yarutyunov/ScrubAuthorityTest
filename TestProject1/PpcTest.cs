using System.ServiceModel;
using Ppc;

namespace TestProject1;

public class PpcTest : TestBase
{
    private readonly PricingAndConfigurationServiceClient _sut;

    public PpcTest()
    {
        _sut = new PricingAndConfigurationServiceClient(new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            },
            new EndpointAddress(new Uri("https://promostandards.scrubauthority.com/api/ppc")));
    }

    [Fact]
    public async Task FobPointArray_Should_NotBeNull()
    {
        var result = await _sut.getFobPointsAsync(new GetFobPointsRequest
        {
            wsVersion = "1.0.0",
            id = "esp",
            password = ServicePassword,
            localizationCountry = "US",
            localizationLanguage = "en",
            productId = "ADR2600"
        });

        Assert.NotNull(result.GetFobPointsResponse);
    }

    [Fact]
    public async Task Ppc_Should_NotBeNull()
    {
        var result = await _sut.getConfigurationAndPricingAsync(new GetConfigurationAndPricingRequest
        {
            wsVersion = "1.0.0",
            id = "esp",
            password = ServicePassword,
            localizationCountry = "US",
            localizationLanguage = "en",
            productId = "ADR2600",
            fobId = "1",
            priceType = priceType.List,
            configurationType = configurationType.Blank,
            currency = CurrencyCodeType.USD
        });

        Assert.NotNull(result.GetConfigurationAndPricingResponse);
    }
}