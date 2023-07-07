using System.Collections;
using System.Net.Http.Headers;
using Domain.Entities;

namespace Domain.Test;

public class UnitTest1
{
    [Fact]
    public void CreatePrice_IncorrectData_ShouldBeException()
    {
        var price = Price.Create(-1);
        var ex = Assert.Throws<Exception>(() => price.Value);
        Assert.Equal("Must be more 0", ex.Message);
    }

    [Fact]
    public void CreateProduct()
    {
        var fake = new FakeData();
        var price = fake.FakePrice(100);
        var product = fake.FakeProduct(price, "Продукт");
        
        Assert.Same(product, typeof(Product));
    }
    
    
    
}