using System.Net.NetworkInformation;
using System.Reflection;
using Application;
using Application.Product.Queries.AllProducts;
using Domain.Common.Repository;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Persistance;
using Infrastructure.Repositories.Order;
using Infrastructure.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Endpoints.Product.GetAll;


var builder = WebApplication
    .CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
builder.Services.AddScoped(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<Product>>), typeof(GetAllProductQueryHandler));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));


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
app.UseRouting();
app.UseSwaggerUI();

app.MapGet("", context =>
{
    context.Response.Redirect("./swagger/index.html", permanent: false);
    return Task.FromResult(0);
});

app.Run();