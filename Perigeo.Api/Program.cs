using Microsoft.EntityFrameworkCore;
using Perigeo.Api.Data;
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

builder.Services.AddDbContext<PerigeoDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Perigeo"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/contactos", async (PerigeoDbContext db) =>
{
    return await db.Contactos.ToListAsync();
});

app.MapGet("/contactos/{id}", async (int id, PerigeoDbContext db) =>
{
    var contacto = await db.Contactos.FindAsync(id);

    if (contacto is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(contacto);
});

app.MapPost("/contactos", async (Contacto contacto, PerigeoDbContext db) =>
{
    contacto.Id = 0;
    contacto.FechaCreacion = DateTime.UtcNow;
    db.Contactos.Add(contacto);
    await db.SaveChangesAsync();

    return Results.Created($"/contactos/{contacto.Id}", contacto);
});

app.MapPut("/contactos/{id}", async (int id, Contacto datos, PerigeoDbContext db) =>
{
    var contacto = await db.Contactos.FindAsync(id);

    if (contacto is null)
    {
        return Results.NotFound();
    }

    contacto.Nombre = datos.Nombre;
    contacto.Apellidos = datos.Apellidos;
    contacto.Telefono = datos.Telefono;
    contacto.Email = datos.Email;
    contacto.Empresa = datos.Empresa;
    contacto.Cumpleanos = datos.Cumpleanos;
    contacto.Notas = datos.Notas;
    contacto.EsFavorito = datos.EsFavorito;
    contacto.Color = datos.Color;
    contacto.Orbita = datos.Orbita;
    await db.SaveChangesAsync();

    return Results.Ok(contacto);
});

app.MapDelete("/contactos/{id}", async (int id, PerigeoDbContext db) =>
{
    var contacto = await db.Contactos.FindAsync(id);

    if (contacto is null)
    {
        return Results.NotFound();
    }

    db.Contactos.Remove(contacto);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();