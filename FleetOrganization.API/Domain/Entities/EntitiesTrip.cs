using FleetOrganization.DOMAIN.Entities;

namespace FleetOrganization.API.Domain.Entities;

public class EntitiesTrip
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime DateMatch { get; set; }
    public DateTime DateArrival { get; set; }
    public string Status { get; set; } = string.Empty;

    //Relacionamento Veiculo
    public int VehicleId { get; set; }
    public EntitiesVehicle? EntitiesVehicle { get; set; }

    //Relacionamento Motorista
    public int DriverId { get; set; }
    public EntitiesDriver? EntitiesDriver { get; set; }

}
