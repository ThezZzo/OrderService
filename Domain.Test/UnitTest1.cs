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
}