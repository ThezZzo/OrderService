using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using WebAPI.Configuration;
using WebAPI.Endpoints.Cart.AddCartItem;
using WebAPI.Endpoints.Cart.AddCartItem.V1;
using WebAPI.Endpoints.Cart.CreateCart.V1;
using WebAPI.Endpoints.Cart.DeleteCartItemFromCart.V1;
using WebAPI.Endpoints.Cart.GetCart.V1;
using WebAPI.Endpoints.Order.CancelOrder.V1;
using WebAPI.Endpoints.Order.CheckoutOrder.V1;
using WebAPI.Endpoints.Order.ReturnAllOrders.V1;
using WebAPI.Endpoints.Product.AddProduct.V1;
using WebAPI.Endpoints.Product.DeleteProduct.V1;
using WebAPI.Endpoints.Product.GetAllProducts.V1;
using WebAPI.Endpoints.Product.GetProductById.V1;
using WebAPI.Endpoints.Product.UpdateProductById.V1;


var builder = WebApplication
    .CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureMediator();




// foreach (var service in builder.Services)
// {
//     Console.WriteLine($"{service.ServiceType.FullName},{service.ImplementationType?.FullName}");
// }


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();
app.UseSwagger();


app.MapGetAllProduct();
app.MapGetProductById();
app.MapCreateProduct();
app.MapDeleteProduct();
app.MapUpdateProduct();

app.MapGetAllOrders();
app.MapCreateOrder();
app.MapDeleteOrder();

app.MapCreateCart();
app.MapAddCartItem();
app.MapGetCart();
app.MapDeleteCartItemFromCart();

app.UseRouting();
app.UseSwaggerUI();

app.MapGet("", context =>
{
    context.Response.Redirect("./swagger/index.html", permanent: false);
    return Task.FromResult(0);
});

app.Run();

public partial class Program { }