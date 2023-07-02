using System.Collections;
using System.Net;
using System.Net.Http.Json;
using Application.Product.Queries.AllProducts;
using Domain.Common.Repository;
using Moq;


namespace Domain.Test.Domain.Product.Tests;

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
        mock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()).Result);
        var handler = new GetAllProductQueryHandler(mock.Object);

        var target = handler.Handle(new GetAllProductQuery(), CancellationToken.None);

        var response = await _client.GetAsync("api/products");
        Assert.Equal(target.Result.GetType(), _products.GetType());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private Entities.Product[] _products =
    {
        new Entities.Product { Name = "Продукт", Price = 200M }
    };
}