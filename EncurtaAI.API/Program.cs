using EncurtaAI.API.Contexts;
using EncurtaAI.API.DTOs.Requests;
using EncurtaAI.API.DTOs.Responses;
using EncurtaAI.API.Repositories;
using EncurtaAI.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("connection"));
});

//builder.Services.AddDbContext<DataContext>(
//    option => option.UseInMemoryDatabase("database")
//);

builder.Services.AddTransient<IURLRepository, URLRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/shorten-url", async (CreateShortURLRequest request, HttpContext context, IURLRepository repository) =>
{
    var baseURL = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/r/"; 

    var response = await repository.CreateURL(request.URL, baseURL);

    return Results.Created(string.Empty, response);
})
.Produces<CreateShortURLResponse>()
.WithName("Shorten URL")
.WithDescription("Encurta a URL que foi passada como parametro")
.WithOpenApi();

app.MapGet("/r/{ShortURL}", async (string ShortURL, HttpContext context, IURLRepository repository) =>
{
    var response = await repository.GetURLByShortURL(ShortURL);

    return response == null ? Results.NotFound() : Results.Redirect(response);
})
.WithName("Redirect URL")
.WithDescription("Redireciona a pagina para a URL vinculada a URL encurtada.")
.WithSummary("Não funciona no Swagger.")
.WithOpenApi();

app.SeedDatabaseAsync().Wait();

app.Run();
