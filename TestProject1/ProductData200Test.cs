using System.ServiceModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using ProductData200;

namespace TestProject1;

public class ProductData200Test : TestBase
{
    private readonly ProductDataServiceClient _sut;

    public ProductData200Test()
    {
        _sut = new ProductDataServiceClient(new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            },
            new EndpointAddress(new Uri("https://promostandards.scrubauthority.com/api/product_data")));
    }

    [Fact]
    public async Task GetProductSellable_FullResponse_Should_NotBeNull()
    {
        var result = await _sut.getProductSellableAsync(new GetProductSellableRequest
        {
            wsVersion = "2.0.0",
            id = "esp",
            password = ServicePassword,
            localizationCountry = "US",
            localizationLanguage = "en",
            isSellable = true
        });

        Assert.NotNull(result.GetProductSellableResponse);
    }

    [Fact]
    public async Task GetProductSellable_ProductResponse_Should_NotBeNull()
    {
        var result = await _sut.getProductSellableAsync(new GetProductSellableRequest
        {
            wsVersion = "2.0.0",
            id = "esp",
            password = ServicePassword,
            localizationCountry = "US",
            localizationLanguage = "en",
            isSellable = true,
            productId = "ADR2600"
        });

        Assert.NotNull(result.GetProductSellableResponse);
    }

    [Fact]
    public async Task GetProductResponse_Should_NotBeNull()
    {
        var result = await _sut.getProductAsync(new GetProductRequest
        {
            wsVersion = "2.0.0",
            id = "esp",
            password = ServicePassword,
            localizationCountry = "US",
            localizationLanguage = "en",
            productId = "ADR2600"
        });

        Assert.NotNull(result.GetProductResponse);
    }
}