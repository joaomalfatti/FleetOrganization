namespace FleetOrganiztion.COMMUNICATION.Requests;

public class RequestUserJson
{
    //É um pedido que o client faz ao servidor, contendo dados que descrevem o que o cliente precisa
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string TypeUser { get; set; } = string.Empty;

}

