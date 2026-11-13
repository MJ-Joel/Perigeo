using Microsoft.EntityFrameworkCore;
using Perigeo.Core;

namespace Perigeo.Api.Data;

public class PerigeoDbContext(DbContextOptions<PerigeoDbContext> options) : DbContext(options)
{
    public DbSet<Contacto> Contactos => Set<Contacto>();
}