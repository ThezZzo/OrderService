using System.Net;
using Application.Product.Queries.AllProducts;
using Domain.Common.Repository;
using Domain.Entities;
using Domain.ValueObjects;
using Moq;

namespace Domain.Test.Application.Test.Product.Queries;

public class GetAllProducts
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;

    public GetAllProducts()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }
    
    [Fact]
    public async void Get_All_Products()
    {
        var mock = new Mock<IProductRepository>();
        mock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()).Result).Returns(_products);
        var handler = new GetAllProductQueryHandler(mock.Object);

        var target = handler.Handle(new GetAllProductQuery(), CancellationToken.None);

        var response = await _client.GetAsync("api/products");
        Assert.Equal(target.Result.GetType(), _products.GetType());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private Entities.Product[] _products =
    {
        new Entities.Product { Name = "Продукт", Price = Price.Create(200) }
    };
}