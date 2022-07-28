using GFood_CaseStudy.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/GetProducts", ([FromServices] IProductService _productService) =>
{
    var result = _productService.GetList();
    if (result.IsSuccess)
    {
        return Results.Ok(value: result);
    }
    return Results.BadRequest(error: result);
})
.WithName("GetProducts");

app.Run();
