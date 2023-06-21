using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using WebAPI.Configuration;
using WebAPI.Endpoints.Product.GetAll;


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
app.UseRouting();
app.UseSwaggerUI();

app.MapGet("", context =>
{
    context.Response.Redirect("./swagger/index.html", permanent: false);
    return Task.FromResult(0);
});

app.Run();