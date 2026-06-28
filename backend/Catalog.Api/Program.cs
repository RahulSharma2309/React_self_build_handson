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

var products = new[]
{
    new Product(1, "Arduino Sensor Starter Lab", "arduino-sensor-starter-lab", "Microcontrollers", 2499, 4.8, 18, "Best seller",
        "https://images.unsplash.com/photo-1518770660439-4636190af475?auto=format&fit=crop&w=900&q=80",
        "A beginner-friendly kit with Arduino Uno, breadboard, jumper wires, and 12 sensor modules.",
        "Build temperature monitors, motion alarms, soil sensors, light meters, and small automation projects while learning embedded electronics.",
        ["Arduino Uno compatible board", "12 plug-and-play sensors", "180-page project guide", "USB cable and jumper kit"]),
    new Product(2, "Raspberry Pi Home Automation Pack", "raspberry-pi-home-automation-pack", "IoT", 6999, 4.7, 9, "IoT ready",
        "https://images.unsplash.com/photo-1553406830-ef2513450d76?auto=format&fit=crop&w=900&q=80",
        "Everything needed to prototype a smart-room dashboard with relays, sensors, and Pi accessories.",
        "Use this kit to create smart lights, fan control, energy monitoring, and local dashboards backed by simple APIs.",
        ["Raspberry Pi compatible accessories", "4-channel relay board", "DHT22 and PIR sensors", "Case, fan, and power supply"]),
    new Product(3, "ESP32 Robotics Controller Kit", "esp32-robotics-controller-kit", "Robotics", 3799, 4.6, 14, "Wi-Fi + BLE",
        "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?auto=format&fit=crop&w=900&q=80",
        "ESP32 board, motor driver, wheels, chassis, and sensors for building connected robots.",
        "Practice PWM, motor control, obstacle avoidance, Bluetooth commands, and REST-connected robot telemetry.",
        ["ESP32 development board", "L298N motor driver", "Ultrasonic distance sensor", "Robot chassis and wheels"]),
    new Product(4, "Soldering and PCB Prototyping Bench", "soldering-pcb-prototyping-bench", "Tools", 5299, 4.9, 7, "Workshop",
        "https://images.unsplash.com/photo-1581092160607-ee22731c9c98?auto=format&fit=crop&w=900&q=80",
        "A clean bench setup for assembling and testing custom electronics projects.",
        "Includes essentials for soldering, measuring, debugging, and organizing real prototype circuits.",
        ["60W temperature-controlled iron", "Digital multimeter", "Helping hands stand", "Perfboard and connector set"]),
    new Product(5, "Drone Flight Controller Learning Kit", "drone-flight-controller-learning-kit", "Robotics", 8499, 4.5, 5, "Advanced",
        "https://images.unsplash.com/photo-1508614589041-895b88991e3e?auto=format&fit=crop&w=900&q=80",
        "A compact kit for understanding IMUs, ESCs, brushless motors, and flight control basics.",
        "Great for learning sensor fusion, PID loops, motor calibration, and safe drone prototyping workflows.",
        ["F4 flight controller", "4 brushless motors", "ESC set", "IMU calibration worksheet"]),
    new Product(6, "AI Vision Edge Camera Bundle", "ai-vision-edge-camera-bundle", "AI Edge", 9999, 4.8, 11, "New",
        "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?auto=format&fit=crop&w=900&q=80",
        "Prototype computer vision projects with an edge board, camera module, and lighting kit.",
        "Run object detection demos, collect image datasets, and learn how edge devices talk to dashboards.",
        ["Edge AI accelerator board", "8MP camera module", "Adjustable LED light", "Sample model cards"]),
};

app.MapGet("/", () => Results.Ok(new { service = "Catalog.Api", status = "running" }));
app.MapGet("/products", () => Results.Ok(products));
app.MapGet("/products/{slug}", (string slug) =>
{
    var product = products.FirstOrDefault(item => item.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
    return product is null ? Results.NotFound(new { message = "Product not found." }) : Results.Ok(product);
});

app.Run();

public record Product(
    int Id,
    string Name,
    string Slug,
    string Category,
    decimal Price,
    double Rating,
    int Stock,
    string Badge,
    string Image,
    string Summary,
    string Description,
    string[] Specs);
