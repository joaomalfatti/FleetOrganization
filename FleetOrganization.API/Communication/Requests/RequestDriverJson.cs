namespace FleetOrganiztion.COMMUNICATION.Requests;

public class RequestDriverJson
{
    //É um pedido que o client faz ao servidor, contendo dados que descrevem o que o cliente precisa
    public string Name { get; set; } = string.Empty;
    public string CNH { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // A,B,C,D,E
    public string Telephone { get; set; } = string.Empty;
    public bool Disponibility { get; set; } = true;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public List<Trip>? Trips { get; set; }
}

