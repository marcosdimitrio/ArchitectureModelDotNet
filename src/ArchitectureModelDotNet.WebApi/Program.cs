using ArchitectureModelDotNet.WebApi.Setup;
using SimpleInjector;

var container = new Container();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerConfig.Configure);

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
       .AddControllerActivation();
});

SimpleInjectorConfig.InitializeContainer(container, Lifestyle.Scoped, builder.Configuration);

var app = builder.Build();

app.Services.UseSimpleInjector(container);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

container.Verify();

app.Run();
