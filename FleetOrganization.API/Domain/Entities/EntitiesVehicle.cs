namespace FleetOrganization.API.Domain.Entities;

public class EntitiesVehicle
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Model { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public int Year { get; set; }
    public string TypeVehicle { get; set; } = string.Empty;
    public bool Disponibility { get; set; } = true;



    //Relacionamento com a tabela de TRIPS
    public List<EntitiesTrip>? EntitiesTrips { get; set; }
}
