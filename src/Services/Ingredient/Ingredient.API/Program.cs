using Ingredient.API.Entity;
using Ingredient.API.Data;
using Ingredient.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title ="Ingredient.API", Version="v1" });  
});

builder.Services.Configure<IngredientDatabaseSettings>(builder.Configuration.GetSection("IngredientDatabaseSettings"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IIngredientContext, IngredientContext>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ingredient.API v1"));
}


app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

