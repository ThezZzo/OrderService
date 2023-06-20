using Application;
using Infrastructure;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Endpoints.Product.GetAll;


var builder = WebApplication
    .CreateBuilder(args);
builder.Services
    .ConfigureInfrastructure()
    .ConfigureApplication();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


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