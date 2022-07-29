using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Business.DependencyResolvers.Autofac;
using GFood_CaseStudy.Core.DependencyResolvers;
using GFood_CaseStudy.Core.Extensions;
using GFood_CaseStudy.Core.Utilities.IoC;
using GFood_CaseStudy.Entities.DTOs;
using GFood_CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Mvc;

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

app.MapGet("/GetSuitables/{basketId}", (ICampaignService _campaignService, IMapper _mapper, int basketId) =>
{
    var result = _campaignService.GetSuitableCampaigns(basketId);
    if (result.IsSuccess)
    {
        return Results.Ok(_mapper.Map<IEnumerable<CampaignDto>>(result.Data));
    }
    return Results.BadRequest(result);
})
.WithName("GetSuitables");

app.MapPost("/UseCampaign", (ICampaignService _campaignService, IMapper _mapper, [FromBody] BasketCampaignDto basketCampaignDto) =>
{
    var result = _campaignService.UseCampaign(_mapper.Map<BasketCampaign>(basketCampaignDto));
})
.WithName("UseCampaign");

app.Run();
