namespace FleetOrganization.DOMAIN.Entities;

public class EntitiesUser
{
    // Espelho exatamente como as colunas de DB.

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string TypeUser { get; set; } = string.Empty;
}

