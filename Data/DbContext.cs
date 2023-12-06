using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// DbContext.cs
public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Datos { get; set; } // Cambiado el nombre de la propiedad a "Datos"

  
}
// Agrega esta anotación a tu modelo Cliente para especificar el nombre de la tabla
