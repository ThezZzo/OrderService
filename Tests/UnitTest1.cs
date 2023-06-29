using System.Net;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests;


[TestFixture]
public class Tests
{
    private  WebApplicationFactory<Program> _factory;

   
    [SetUp]
    public void Setup( )
    {
        _factory = new WebApplicationFactory<Program>();
    }
    [Test]
    public async Task GetAllProducts()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/products");
        var data = await response.Content.ReadAsStringAsync();
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    
}