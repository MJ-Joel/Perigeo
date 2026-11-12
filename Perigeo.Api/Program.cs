using Perigeo.Core;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var contactos = new List<Contacto>
{
    new Contacto{ Id = 1, Nombre = "Carla", Apellidos = "Ruiz", Telefono = "+34 600 000 112"},
    new Contacto{ Id = 2, Nombre = "Javier", Apellidos = "García", Telefono = "+34 600 000 113", Email = "javier.garcia@example.com", Orbita = Orbita.Cercana},
    new Contacto{ Id = 3, Nombre = "Lucía", Apellidos = "Martínez", Telefono = "+34 600 000 114", Color = ColorContacto.Lima, EsFavorito = true}
};

app.MapGet("/contactos", () => contactos);

app.MapGet("/contactos/{id}", (int id) =>
{
    var contacto = contactos.FirstOrDefault(c => c.Id == id);

    if (contacto is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(contacto);

});

app.MapPost("/contactos", (Contacto contacto) =>
{
    contacto.Id = contactos.Max(c => c.Id) + 1;
    contactos.Add(contacto);

    return Results.Created($"/contactos/{contacto.Id}", contacto);
});

app.Run();

