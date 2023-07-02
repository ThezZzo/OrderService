using System.Net;
using System.Net.Http.Json;
using Application.Product.Commands.Create;
using Domain.Common.Repository;
using Domain.Test.Domain.Product.Test;
using Moq;

namespace Domain.Test.Domain.Product.Tests;

public class PostProduct
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;

    public PostProduct()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }
    
    [Fact]
    public async void Post_Product_With_Correct_Data()
    {
        var mock = new Mock<IProductRepository>();
        mock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()).Result);
        var handler = new CreateProductCommandHandler(mock.Object);
        
        var fakeProduct = new Entities.Product
        {
            Name = "Продукт",
            Price = 1000
        };

        var target = handler.Handle(new CreateProductCommand(), CancellationToken.None);
        var response = await _client.PostAsJsonAsync("/api/products", fakeProduct);
        Assert.Equal(fakeProduct.GetType(), target.GetType());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void Post_Product_With_Incorrect_Data()
    {
        var mock = new Mock<IProductRepository>();
        var fakeProduct = new FakeProduct
        {
            Name = "Продукт",
            Price = "rweew"
        };
        var client = _factory.CreateClient();
        var response = await client.PostAsJsonAsync("/api/products", fakeProduct);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}