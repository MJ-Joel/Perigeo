namespace Perigeo.Core;

public class Contacto
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Apellidos { get; set; }
    public required string Telefono { get; set; }
    public string? Email { get; set; }
    public string? Empresa { get; set; }
    public DateOnly? Cumpleanos { get; set; }
    public string? Notas { get; set; }
    public bool EsFavorito { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
