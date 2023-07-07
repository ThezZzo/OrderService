using System.Net;
using System.Net.Http.Json;
using Application.Product.Commands.Create;
using Domain.Common.Repository;
using Domain.Entities;
using Domain.Test.Domain.Product.Test;
using Domain.ValueObjects;
using Moq;

namespace Domain.Test.Application.Test.Product.Commands;

public class CreateProduct
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;

    public CreateProduct()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }
    
    [Fact]
    public async void PostProduct_WithIncorrectData_ShouldBeOk()
    {
        var price = Price.Create(100);
        var fakeProduct = Entities.Product.Create(price,"Product");

        var mock = new Mock<IProductRepository>();
        mock.Setup(r => r.AddEntityAsync(fakeProduct, It.IsAny<CancellationToken>()));
        var handler = new CreateProductCommandHandler(mock.Object);
        
        var target = handler.Handle(new CreateProductCommand(), CancellationToken.None).Result;
        var response = await _client.PostAsJsonAsync("/api/products", fakeProduct);
        Assert.Equal(fakeProduct.GetType(), target.GetType());
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void PostProduct_WithIncorrectData_ShouldBeBadRequest()
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