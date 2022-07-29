using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Business.DependencyResolvers.Autofac;
using GFood_CaseStudy.Core.DependencyResolvers;
using GFood_CaseStudy.Core.Extensions;
using GFood_CaseStudy.Core.Utilities.IoC;
using GFood_CaseStudy.Entities.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(b =>
{
    b.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
//builder.Services.AddSession();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.WithOrigins("*");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureCustomExceptionMiddleware();

app.MapGet("/GetBasket/{id}", (IBasketService _basketService, IMapper _mapper, int id) =>
{
    var result = _basketService.GetById(id);
    if (result.IsSuccess)
    {
        return Results.Ok(_mapper.Map<BasketDto>(result.Data));
    }
    return Results.BadRequest(result);
})
.WithName("GetBasket");

app.Run();
