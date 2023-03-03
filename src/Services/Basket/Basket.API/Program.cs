

using Basket.API.Entity;
using Microsoft.Extensions.Options;
using Basket.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));


builder.Services.AddStackExchangeRedisCache( option => 
    { 
        option.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
    });

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Basket.API", Version = "v1" });
    //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
    //app.UseSwaggerUI();
}


app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();



