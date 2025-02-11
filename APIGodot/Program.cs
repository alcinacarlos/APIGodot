using APIGodot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var jugador = new Jugador("Heroe");
var enemigo = new Enemigo("Villano");

app.MapGet("/jugador", () => jugador);
app.MapGet("/enemigo", () => enemigo);

app.MapPost("/jugador/atacar", () =>
{
    jugador.Atacar(enemigo);
    return Results.Ok(new { mensaje = $"{jugador.Nombre} atacó a {enemigo.Nombre}" });
});

app.MapPost("/enemigo/atacar", () =>
{
    enemigo.Atacar(jugador);
    return Results.Ok(new { mensaje = $"{enemigo.Nombre} atacó a {jugador.Nombre}" });
});

app.MapPost("/jugador/subir-nivel", () =>
{
    jugador.SubirNivel();
    return Results.Ok(new { mensaje = $"{jugador.Nombre} subió de nivel" });
});

app.MapPost("/enemigo/subir-nivel", () =>
{
    enemigo.SubirNivel();
    return Results.Ok(new { mensaje = $"{enemigo.Nombre} subió de nivel" });
});

app.Run();