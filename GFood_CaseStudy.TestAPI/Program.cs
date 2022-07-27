using Autofac;
using Autofac.Extensions.DependencyInjection;
using GFood_CaseStudy.Business.DependencyResolvers.Autofac;
using GFood_CaseStudy.Core.DependencyResolvers;
using GFood_CaseStudy.Core.Extensions;
using GFood_CaseStudy.Core.Utilities.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(b =>
{
    b.RegisterModule(new AutofacBusinessModule());
});
//builder.Services.AddSession();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.WithOrigins("*");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(action =>
{
    action.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GFood_CaseStudy.TestAPI",
        Version = "v1",
    });
});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();
//app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(action => action.SwaggerEndpoint("/swagger/v1/swagger.json", "GFood_CaseStudy.TestAPI.UI v1"));
}

app.ConfigureCustomExceptionMiddleware();

app.UseCors(policy =>
{
    policy.WithOrigins("*").AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
