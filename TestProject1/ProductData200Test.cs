using System.ServiceModel;
using ProductData200;

namespace TestProject1;

public class ProductData200Test
{
    [Fact]
    public async Task GetProductResponse_Should_NotBeNull()
    {
        var sut = new ProductDataServiceClient(new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            },
            new EndpointAddress(new Uri("https://promostandards.scrubauthority.com/api/product_data")));

        var result = await sut.getProductAsync(new GetProductRequest
        {
            wsVersion = "2.0.0",
            id = "esp",
            password = "",
            localizationCountry = "US",
            localizationLanguage = "en",
            productId = "KOI763"
        });

        Assert.NotNull(result.GetProductResponse);
    }
}