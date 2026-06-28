using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();

var orders = new ConcurrentDictionary<Guid, Order>();

app.MapGet("/", () => Results.Ok(new { service = "Orders.Api", status = "running" }));
app.MapGet("/orders", () => Results.Ok(orders.Values.OrderByDescending(order => order.CreatedAt)));

app.MapPost("/orders", (CreateOrderRequest request) =>
{
    if (request.Items.Count == 0)
    {
        return Results.BadRequest(new { message = "An order must contain at least one item." });
    }

    var order = new Order(
        Guid.NewGuid(),
        $"VS-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}",
        request.Customer,
        request.Items,
        request.Total,
        DateTimeOffset.UtcNow);

    orders[order.Id] = order;

    return Results.Created($"/orders/{order.Id}", order);
});

app.Run();

public record CreateOrderRequest(Customer Customer, List<OrderItem> Items, decimal Total);
public record Order(Guid Id, string OrderNumber, Customer Customer, List<OrderItem> Items, decimal Total, DateTimeOffset CreatedAt);
public record Customer(string Name, string Email, string Address);
public record OrderItem(int Id, string Name, decimal Price, int Quantity);
