using FleetOrganization.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetOrganization.INFRAESTRUCTURE.DataAccess;
public class FleetOrganizationDbContext : DbContext
{
    public DbSet<EntitiesUser> tb_users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Criando uma conexão direta no meu arquivo de banco de dados.
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\joaom\\Documents\\trabalhos\\FleetOrganizationDb.db");
    }

}

