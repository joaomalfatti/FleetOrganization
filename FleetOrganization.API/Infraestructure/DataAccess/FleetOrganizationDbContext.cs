using FleetOrganization.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetOrganization.API.Infraestructure.DataAccess;
public class FleetOrganizationDbContext : DbContext
{
    public DbSet<EntitiesDriver> tbDrivers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Criando uma conexão direta no meu arquivo de banco de dados.
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\joaom\\Documents\\trabalhos\\FleetOrganizationDb.db");
    }

}

