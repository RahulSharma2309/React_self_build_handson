using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddHttpClient("catalog", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Catalog"] ?? "http://localhost:5201");
});

builder.Services.AddHttpClient("orders", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Orders"] ?? "http://localhost:5202");
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => Results.Ok(new { service = "Gateway.Api", status = "running" }));

app.MapGet("/api/products", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("catalog");
    var response = await client.GetAsync("/products");
    return await ToGatewayResult(response);
});

app.MapGet("/api/products/{slug}", async (string slug, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("catalog");
    var response = await client.GetAsync($"/products/{Uri.EscapeDataString(slug)}");
    return await ToGatewayResult(response);
});

app.MapGet("/api/orders", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("orders");
    var response = await client.GetAsync("/orders");
    return await ToGatewayResult(response);
});

app.MapPost("/api/orders", async (CreateOrderRequest request, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("orders");
    var response = await client.PostAsJsonAsync("/orders", request);
    return await ToGatewayResult(response);
});

app.Run();

static async Task<IResult> ToGatewayResult(HttpResponseMessage response)
{
    var content = await response.Content.ReadAsStringAsync();
    return Results.Content(content, "application/json", statusCode: (int)response.StatusCode);
}

public record CreateOrderRequest(Customer Customer, List<OrderItem> Items, decimal Total);
public record Customer(string Name, string Email, string Address);
public record OrderItem(int Id, string Name, decimal Price, int Quantity);
