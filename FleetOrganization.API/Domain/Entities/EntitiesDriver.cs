namespace FleetOrganization.API.Domain.Entities;

public class EntitiesDriver
{
    // Espelho exatamente como as colunas de DB.

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string CNH { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // A,B,C,D,E
    public string Telephone { get; set; } = string.Empty;
    public bool Disponibility { get; set; } = true;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    //Relacionamento com a tabela de TRIPS
    public List<EntitiesTrip>? EntitiesTrips { get; set; }
}

